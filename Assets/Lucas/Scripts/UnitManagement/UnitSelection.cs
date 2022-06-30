using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class UnitSelection : MonoBehaviour
{
    List<ShipInteractable> selectedShips = new List<ShipInteractable>();
    [SerializeField] string playerShipTag;
    bool isAdding;

    [SerializeField] UnityEvent deselectFleetCard;

    Camera cam;
    [SerializeField] RectTransform selectionBoxVisual;

    Rect selectionBox;

    Vector2 startPos;
    Vector2 endPos;

    private void Awake()
    {
        cam = Camera.main;
        startPos = Vector2.zero;
        endPos = Vector2.zero;

        DrawOnCanvas();
    }

    private void Update()
    {
        //NOTE: When shift is pressed ships that have not been added to the selectedShips can be added to the existing list
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            isAdding = true;
        }

        if (Input.GetMouseButtonDown(0))
        {
            startPos = Input.mousePosition;
            selectionBox = new Rect();
            deselectFleetCard?.Invoke();
        }

        if (Input.GetMouseButton(0))
        {
            endPos = Input.mousePosition;
            DrawOnCanvas();
            DrawSelection();
        }

        if (Input.GetMouseButtonUp(0))
        {
            if (!isAdding)
            {
                DeselectAllShips();
            }

            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform.gameObject.tag != playerShipTag && !isAdding)
                {
                    DeselectAllShips();
                }
                else if (hit.transform.gameObject.tag == playerShipTag && isAdding)
                {
                    AddShipsToSelected(hit.transform.GetComponent<ShipInteractable>());
                }
                else if (hit.transform.gameObject.tag == playerShipTag)
                {
                    selectedShips.Add(hit.transform.GetComponent<ShipInteractable>());
                    selectedShips[selectedShips.Count - 1].EnableSelectionRing();
                }
                else if (!isAdding)
                {
                    DeselectAllShips();
                }
            }

            SelectUnitsFromBox();
            startPos = Vector2.zero;
            endPos = Vector2.zero;
            DrawOnCanvas();
        }

        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            isAdding = false;
        }
    }

    //NOTE: Draws the rectangle of the unit selection
    public void DrawOnCanvas()
    {
        Vector2 boxStart = startPos;
        Vector2 boxEnd = endPos;

        Vector2 boxCentre = (boxStart + boxEnd) / 2;
        selectionBoxVisual.position = boxCentre;

        Vector2 boxSize = new Vector2(Mathf.Abs(boxStart.x - boxEnd.x), Mathf.Abs(boxStart.y - boxEnd.y));

        selectionBoxVisual.sizeDelta = boxSize;
    }

    //NOTE: Pain
    private void DrawSelection()
    {
        if (Input.mousePosition.x < startPos.x)
        {
            selectionBox.xMin = Input.mousePosition.x;
            selectionBox.xMax = startPos.x;
        }
        else
        {
            selectionBox.xMin = startPos.x;
            selectionBox.xMax = Input.mousePosition.x;
        }

        if (Input.mousePosition.y < startPos.y)
        {
            selectionBox.yMin = Input.mousePosition.y;
            selectionBox.yMax = startPos.y;
        }
        else
        {
            selectionBox.yMin = startPos.y;
            selectionBox.yMax = Input.mousePosition.y;
        }
    }

    //Checks the box which ships are inside of it and adds them to the selectedShips
    private void SelectUnitsFromBox()
    {
        foreach (ShipInteractable ship in ShipList.instance.playerShips)
        {
            if (selectionBox.Contains(cam.WorldToScreenPoint(ship.transform.position)))
            {
                if (!selectedShips.Contains(ship))
                {
                    selectedShips.Add(ship);
                    ship.EnableSelectionRing();
                }
            }
        }
    }

    public void OverrideCurrentSelection(List<ShipInteractable> ships)
    {
        DeselectAllShips();
        AddShipsToSelected(ships.ToArray());
    }

    public void AddShipsToSelected(params ShipInteractable[] ships)
    {
        foreach (ShipInteractable ship in ships)
        {
            if (!selectedShips.Contains(ship))
            {
                selectedShips.Add(ship);
                selectedShips[selectedShips.Count - 1].EnableSelectionRing();
            }
            else
            {
                RemoveShipsFromSelected(ship);
            }
        }
    }

    public void RemoveShipsFromSelected(params ShipInteractable[] ships)
    {
        foreach (ShipInteractable ship in ships)
        {
            ship.DisableSelectionRing();
            selectedShips.Remove(ship);
        }
    }

    public void DeselectAllShips()
    {
        foreach (ShipInteractable ship in selectedShips)
        {
            ship.DisableSelectionRing();
        }
        selectedShips.Clear();
    }

    public List<ShipInteractable> GetSelectedShips()
    {
        return selectedShips;
    }
}

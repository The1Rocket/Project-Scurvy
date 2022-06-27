using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitSelection : MonoBehaviour
{
    List<ShipInteractable> selectedShips = new List<ShipInteractable>();
    [SerializeField] string playerShipTag;
    bool isAdding;
    bool isDragging;

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
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            isAdding = true;
        }

        if (Input.GetMouseButtonDown(0))
        {
            startPos = Input.mousePosition;
            selectionBox = new Rect();
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
                    Debug.Log("Condition 1");
                    DeselectAllShips();
                }
                else if(hit.transform.gameObject.tag == playerShipTag && isAdding)
                {
                    Debug.Log("Condition 2");
                    selectedShips.Add(hit.transform.GetComponent<ShipInteractable>());
                    selectedShips[selectedShips.Count - 1].EnableSelectionRing();
                }
                else if(hit.transform.gameObject.tag == playerShipTag)
                {
                    Debug.Log("Condition 4");
                    selectedShips.Add(hit.transform.GetComponent<ShipInteractable>());
                    selectedShips[selectedShips.Count - 1].EnableSelectionRing();
                }
                else if (!isAdding)
                {
                    Debug.Log("Condition 3");
                    DeselectAllShips();
                }
            }

            SelectUnits();
            startPos = Vector2.zero;
            endPos = Vector2.zero;
            DrawOnCanvas();
        }

        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            isAdding = false;
        }
    }

    public void DrawOnCanvas()
    {
        Vector2 boxStart = startPos;
        Vector2 boxEnd = endPos;

        Vector2 boxCentre = (boxStart + boxEnd) / 2;
        selectionBoxVisual.position = boxCentre;

        Vector2 boxSize = new Vector2(Mathf.Abs(boxStart.x - boxEnd.x), Mathf.Abs(boxStart.y - boxEnd.y));

        selectionBoxVisual.sizeDelta = boxSize;
    }

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

    private void SelectUnits()
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

    public void DeselectAllShips()
    {
        foreach (ShipInteractable ship in selectedShips)
        {
            ship.DisableSelectionRing();
        }
        selectedShips.Clear();
    }
}

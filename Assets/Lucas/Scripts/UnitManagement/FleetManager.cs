using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FleetManager : MonoBehaviour
{
    [SerializeField] UnitSelection unitSelection;
    UnitFleet[] fleets = new UnitFleet[9];
    [SerializeField] FleetCard[] fleetUICards;

    int indexOfCurrentFleet;

    private void Awake()
    {
        for (int i = 0; i < fleets.Length; i++)
        {
            fleets[i] = new UnitFleet(i);
        }
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.LeftControl))
        {
            if (Input.GetKeyDown(KeyCode.F1) && unitSelection.GetSelectedShips().Count > 0)
            {
                fleets[0].fleetShips = unitSelection.GetSelectedShips();
            }
        }

        if (Input.GetKeyDown(KeyCode.Alpha1) && fleets[0].fleetShips.Count > 0)
        {
            SelectFleet(0);
        }
    }

    public void SelectFleet(int fleetIndex)
    {
        indexOfCurrentFleet = fleetIndex;
        unitSelection.DeselectAllShips();
        unitSelection.OverrideCurrentSelection(fleets[fleetIndex].fleetShips);
        MoveUpFleetCard();
    }

    public void MoveDownFleetCard()
    {
        if (indexOfCurrentFleet != -1)
        {
            fleetUICards[indexOfCurrentFleet].MoveCardDownInterpreter();
            indexOfCurrentFleet = -1;
        }
    }

    public void MoveUpFleetCard()
    {
        fleetUICards[indexOfCurrentFleet].MoveCardUpInterpreter();
    }
}
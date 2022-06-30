using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FleetManager : MonoBehaviour
{
    [SerializeField] UnitSelection unitSelection;
    UnitFleet[] fleets = new UnitFleet[9];
    [SerializeField] FleetCard[] fleetUICards;

    [SerializeField] int indexOfCurrentFleet;

    private void Awake()
    {
        for (int i = 0; i < fleets.Length; i++)
        {
            fleets[i] = new UnitFleet(i);
        }
    }

    private void Update()
    {
        //NOTE: This isn't funny, don't laugh you bastard
        if (Input.GetKey(KeyCode.LeftControl))
        {
            if (Input.GetKeyDown(KeyCode.F1) && unitSelection.GetSelectedShips().Count > 0)
            {
                fleets[0].fleetShips = unitSelection.GetSelectedShipsFromTotalShips();
            }
            if (Input.GetKeyDown(KeyCode.F2) && unitSelection.GetSelectedShips().Count > 0)
            {
                fleets[1].fleetShips = unitSelection.GetSelectedShipsFromTotalShips();
            }
            if (Input.GetKeyDown(KeyCode.F3) && unitSelection.GetSelectedShips().Count > 0)
            {
                fleets[2].fleetShips = unitSelection.GetSelectedShipsFromTotalShips();
            }
            if (Input.GetKeyDown(KeyCode.F4) && unitSelection.GetSelectedShips().Count > 0)
            {
                fleets[3].fleetShips = unitSelection.GetSelectedShipsFromTotalShips();
            }
            if (Input.GetKeyDown(KeyCode.F5) && unitSelection.GetSelectedShips().Count > 0)
            {
                fleets[4].fleetShips = unitSelection.GetSelectedShipsFromTotalShips();
            }
            if (Input.GetKeyDown(KeyCode.F6) && unitSelection.GetSelectedShips().Count > 0)
            {
                fleets[5].fleetShips = unitSelection.GetSelectedShipsFromTotalShips();
            }
            if (Input.GetKeyDown(KeyCode.F7) && unitSelection.GetSelectedShips().Count > 0)
            {
                fleets[6].fleetShips = unitSelection.GetSelectedShipsFromTotalShips();
            }
            if (Input.GetKeyDown(KeyCode.F8) && unitSelection.GetSelectedShips().Count > 0)
            {
                fleets[7].fleetShips = unitSelection.GetSelectedShipsFromTotalShips();
            }
            if (Input.GetKeyDown(KeyCode.F9) && unitSelection.GetSelectedShips().Count > 0)
            {
                fleets[8].fleetShips = unitSelection.GetSelectedShipsFromTotalShips();
            }
        }

        //I'm fucking serious mate don't laugh
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            MoveDownFleetCard();
            if (fleets[0].fleetShips.Count > 0)
            {
                SelectFleet(0);
                indexOfCurrentFleet = 0;
            }
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            MoveDownFleetCard();
            if (fleets[1].fleetShips.Count > 0)
            {
                SelectFleet(1);
                indexOfCurrentFleet = 1;
            }
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            MoveDownFleetCard();
            if (fleets[2].fleetShips.Count > 0)
            {
                SelectFleet(2);
                indexOfCurrentFleet = 2;
            }
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            MoveDownFleetCard();
            if (fleets[3].fleetShips.Count > 0)
            {
                SelectFleet(3);
                indexOfCurrentFleet = 3;
            }
        }
        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            MoveDownFleetCard();
            if (fleets[4].fleetShips.Count > 0)
            {
                SelectFleet(4);
                indexOfCurrentFleet = 4;
            }
        }
        if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            MoveDownFleetCard();
            if (fleets[5].fleetShips.Count > 0)
            {
                SelectFleet(5);
                indexOfCurrentFleet = 5;
            }
        }
        if (Input.GetKeyDown(KeyCode.Alpha7))
        {
            MoveDownFleetCard();
            if (fleets[6].fleetShips.Count > 0)
            {
                SelectFleet(6);
                indexOfCurrentFleet = 6;
            }
        }
        if (Input.GetKeyDown(KeyCode.Alpha8))
        {
            MoveDownFleetCard();
            if (fleets[7].fleetShips.Count > 0)
            {
                SelectFleet(7);
                indexOfCurrentFleet = 7;
            }
        }
        if (Input.GetKeyDown(KeyCode.Alpha9))
        {
            MoveDownFleetCard();
            if (fleets[8].fleetShips.Count > 0)
            {
                SelectFleet(8);
                indexOfCurrentFleet = 8;
            }
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
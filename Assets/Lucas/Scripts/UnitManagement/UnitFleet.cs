using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitFleet
{
    public UnitFleet(int ID)
    {
        groupID = ID;
    }

    public List<ShipInteractable> fleetShips = new List<ShipInteractable>();
    public int groupID;
}
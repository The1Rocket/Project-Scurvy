using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipList : MonoSingleton<ShipList>
{
    public List<ShipInteractable> playerShips = new List<ShipInteractable>();

    public void AddShip(ShipInteractable shipToAdd)
    {
        playerShips.Add(shipToAdd);
    }

    public void RemoveShip(ShipInteractable shipToRemove)
    {
        playerShips.Remove(shipToRemove);
    }
}
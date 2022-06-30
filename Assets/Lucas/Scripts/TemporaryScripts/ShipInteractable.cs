using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// TO BE DEPRECATED WHEN MERGING
/// THIS CLASS ONLY SERVES TO TEST THE UNIT SELECTION
/// EVERY CLASS MENTIONING THIS SCRIPT WILL NEED TO BE UPDATED
/// </summary>

public class ShipInteractable : MonoBehaviour
{
    [SerializeField] GameObject selectionRing;

    private void Awake()
    {
        canBeSelectedInDragMode = true;
    }

    private bool canBeSelectedInDragMode;

    public ShipInteractable CanSelect()
    {
        if (canBeSelectedInDragMode)
        {
            return this;
        }
        return null;
    }

    public void EnableSelectionRing()
    {
        selectionRing.SetActive(true);
    }

    public void DisableSelectionRing()
    {
        selectionRing.SetActive(false);
    }
}
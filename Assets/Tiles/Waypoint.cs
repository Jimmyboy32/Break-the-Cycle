using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    // Sets tower has instantiated object
    [SerializeField] Tower towerPrefab; 

    // If tower can be placed on tile
    [SerializeField] bool isPlaceable;
    public bool IsPlaceable { get { return isPlaceable; } } // gives access to property isPlaceable in other scripts

    void OnMouseDown()
    {
        if (isPlaceable)
        {
            bool isPlaced = towerPrefab.CreateTower(towerPrefab, transform.position);
            isPlaceable = !isPlaced;
        }
    }
}

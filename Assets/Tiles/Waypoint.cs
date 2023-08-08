using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    // Sets tower has instantiated object
    [SerializeField] GameObject towerPrefab; 
    // If tower can be placed on tile
    [SerializeField] bool isPlaceable;
    void OnMouseDown()
    {
        if (isPlaceable)
        {
            // Instantiate a tower on the clicked tile
            Instantiate(towerPrefab, transform.position, Quaternion.identity);
            isPlaceable = false;
        }
    }
}

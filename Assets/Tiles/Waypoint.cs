using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    // If tower can be placed on tile
    [SerializeField] bool isPlaceable;
    void OnMouseDown()
    {
        if (isPlaceable)
        {
            // Gives the name of tile if a tower is placeable on it
            Debug.Log(transform.name);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    // Creation of a list for the multiple waypoints of the grid
    [SerializeField] List<Waypoint> path = new List<Waypoint>();
  
    void Start()
    {
        PrintWaypointName(); 
    }

    void PrintWaypointName()
    {
        // For all the waypoints in the established trajectory
        foreach(Waypoint waypoint in path)
        {
            Debug.Log(waypoint.name);
        }
    }

    
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    // Creation of a list for the multiple waypoints of the grid
    [SerializeField] List<Waypoint> path = new List<Waypoint>();
    [SerializeField] float waitTime = 1f;
  
    void Start()
    {
        StartCoroutine(FollowPath());
    }

    // Coroutine that waits X second after giving waypoint coordinates
    IEnumerator FollowPath()
    {
        // For all the waypoints in the established trajectory
        foreach(Waypoint waypoint in path)
        {
            transform.position = waypoint.transform.position;
            yield return new WaitForSeconds(waitTime);
        }
    }

    
}

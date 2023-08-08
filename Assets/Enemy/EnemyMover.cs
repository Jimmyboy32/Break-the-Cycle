using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    // Creation of a list for the multiple waypoints of the grid
    [SerializeField] List<Waypoint> path = new List<Waypoint>();
    [SerializeField] [Range(0f, 5f)] float speed = 1f;
  
    void Start()
    {
        StartCoroutine(FollowPath());
    }

    // Coroutine that waits X second after giving waypoint coordinates
    IEnumerator FollowPath()
    {
        // For all the waypoints in the established trajectory
        // Smooth movement for starting point to destination
        foreach(Waypoint waypoint in path)
        {
            Vector3 startPosition = transform.position;
            Vector3 endPosition = waypoint.transform.position;
            float travelPercent = 0f;

            transform.LookAt(endPosition);

            // Will repeat as long as destination has not been reached (travelPercent < 1f)
            while (travelPercent < 1f)
            {
                travelPercent += Time.deltaTime * speed;
                transform.position = Vector3.Lerp(startPosition, endPosition, travelPercent);
                yield return new WaitForEndOfFrame();
            }
        }
    }

    
}

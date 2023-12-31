using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    // Creation of a list for the multiple waypoints of the grid
    [SerializeField] List<Waypoint> path = new List<Waypoint>();
    [SerializeField] [Range(0f, 5f)] float speed = 1f;

    Enemy enemy;
  
    void OnEnable()
    {
        FindPath();
        ReturnToStart();
        StartCoroutine(FollowPath());
    }

    void Start()
    {
        enemy = GetComponent<Enemy>();
    }

    // Clearing of previous path and each new enemy will follow new path
    void FindPath()
    {
        path.Clear();

        GameObject[] waypoints = GameObject.FindGameObjectsWithTag("Path");

        foreach(GameObject waypoint in waypoints)
        {
            path.Add(waypoint.GetComponent<Waypoint>());
        }
    }

    // Enemy spawns at first grid of path
    void ReturnToStart()
    {
        transform.position = path[0].transform.position;
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

        // Deactivate enemy object at end of path
        enemy.StealGold(); // Steal gold from player when destination is reached
        gameObject.SetActive(false);
    }
}

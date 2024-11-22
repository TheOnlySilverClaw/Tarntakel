using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Path : MonoBehaviour
{
    Waypoint[] waypoints;

    public Waypoint[] Waypoints
    {
        get { return waypoints; }
    }

    void Start()
    {
        waypoints = GetComponentsInChildren<Waypoint>();
    }

    void OnDrawGizmos()
    {
        waypoints = GetComponentsInChildren<Waypoint>();    

        if(waypoints.Length < 2) return;

        Gizmos.color = Color.green;
        
        for(int i = 0; i < waypoints.Length - 1; i++) {
            Vector3 start = waypoints[i].transform.position;
            Vector3 end = waypoints[i+1].transform.position;
            Gizmos.DrawLine(start, end);
        }
        Gizmos.DrawLine(
            waypoints[waypoints.Length - 1].transform.position,
            waypoints[0].transform.position
        );
    }
}

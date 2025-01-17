using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using static DirectionHelper;

public class FollowPath : MonoBehaviour
{
    [SerializeField]
    Path path;

    [SerializeField]
    float speed = 1;

    [SerializeField]
    float tolerance = 1f;

    int index;

    Waypoint last;
    Waypoint next;
    float waypointDistance;

    float delay;

    void Start()
    {
        if(path.Waypoints.Length == 1)
        {
            last = path.Waypoints[0];
            next = last;
            waypointDistance = 0f;
        }
        else if(path.Waypoints.Length > 1)
        {
            last = path.Waypoints[^1];
            next = path.Waypoints[0];
            waypointDistance = distance2d(last, next);
        }
        index = 0;
        delay = 0f;
    }

    void FixedUpdate()
    {

        if(path.Waypoints.Length < 1) return;

        if(delay > 0f)
        {
            delay -= Time.deltaTime;
            return;
        }

        float speed;
        if(path.Waypoints.Length == 1)
        {
            speed = this.speed;
        }
        else
        {
            if(Vector3.Distance(transform.position, next.transform.position) < tolerance)
            {
                next.OnReached?.Invoke();
                nextWaypoint();
            }
            speed = interpolateCurrentSpeed();
        }

        transform.position = Vector3.MoveTowards(
            transform.position,
            next.transform.position,
            speed * Time.deltaTime
        );

        Vector2 direction = next.transform.position - transform.position;
        transform.TurnTowards(direction);
    }

    void OnPlayerDetected(GameObject player)
    {
        delay = 0.25f;
    }

    float interpolateCurrentSpeed()
    {
        
        float targetDistance = Vector2.Distance(
            next.transform.position, transform.position);
        
        float relativeDistance = Math.Clamp(targetDistance / waypointDistance, 0f, 1f);

        float speedMultiplier;
        if(this.last.Speed < this.next.Speed)
        {
            speedMultiplier = Mathf.SmoothStep(
                this.last.Speed, this.next.Speed, 1 - relativeDistance);
        }
        else
        {
            speedMultiplier = Mathf.SmoothStep(
                this.next.Speed, this.last.Speed, relativeDistance);
        }

        return this.speed * speedMultiplier;
    }

    void nextWaypoint()
    {
        last = next;
        index = (index + 1) % path.Waypoints.Length;
        next = path.Waypoints[index];
        waypointDistance = distance2d(last, next);
        delay = last.Delay;
    }

    float distance2d(Waypoint a, Waypoint b)
    {
        return Vector2.Distance(a.transform.position, b.transform.position);
    }
}

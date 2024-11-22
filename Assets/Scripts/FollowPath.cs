using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        if(path.Waypoints.Length == 1) {
            last = path.Waypoints[0];
            next = last;
            waypointDistance = 0f;
        } else if(path.Waypoints.Length > 1) {
            last = path.Waypoints[^1];
            next = path.Waypoints[0];
            waypointDistance = distance2d(last, next);
        }
        index = 0;
        delay = 0f;
    }

    void FixedUpdate()
    {

        // if(path.Waypoints.Length < 1) return;

        if(delay > 0f) {
            delay -= Time.deltaTime;
            return;
        }

        if(path.Waypoints.Length < 2) return;

        if(Vector3.Distance(transform.position, next.transform.position) < tolerance)
        {
            last = next;
            index = (index + 1) % path.Waypoints.Length;
            next = path.Waypoints[index];
            waypointDistance = distance2d(last, next);
            delay = last.Delay;
            return;
        }
        
        float targetDistance = Vector2.Distance(
            next.transform.position, transform.position);
        
        float relativeDistance = Math.Clamp(targetDistance / waypointDistance, 0f, 1f);

        float speedMultiplier;
        if(this.last.Speed < this.next.Speed)
        {
            speedMultiplier = Mathf.SmoothStep(this.last.Speed, this.next.Speed, 1 - relativeDistance);
        }
        else
        {
            speedMultiplier = Mathf.SmoothStep(this.next.Speed, this.last.Speed, relativeDistance);
        }

        float currentSpeed = this.speed * speedMultiplier;

        transform.position = Vector3.MoveTowards(
            transform.position,
            next.transform.position,
            currentSpeed * Time.deltaTime
        );

        Vector3 direction = next.transform.position - transform.position;
        transform.right = direction;

        Vector3 localScale = transform.localScale;
        if(direction.x < 0) {
            localScale.x = 1;
            transform.Rotate(0f, 0f, 180f);
        }
        if(direction.x > 0){
            localScale.x = -1;
        }
        transform.localScale =localScale;
    }

    float distance2d(Waypoint a, Waypoint b)
    {
        return Vector2.Distance(a.transform.position, b.transform.position);
    }
}

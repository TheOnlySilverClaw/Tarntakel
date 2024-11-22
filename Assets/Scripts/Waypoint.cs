using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    [SerializeField]
    float speed = 1f;

    public float Speed
    {
        get { return speed; }
    }

    [SerializeField]
    float delay = 0f;

    public float Delay
    {
        get { return delay; }
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawSphere(transform.position, 0.2f);
    }
}

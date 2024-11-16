using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public GameObject[] waypoints;
    public float speed = 1.2f;
    private int waypointIndex = 0;
    private Vector3 targetPosition;

    // Start is called before the first frame update
    void Start()
    {
        targetPosition = waypoints[0].transform.position;
    }


    // Update is called once per frame
    void Update()
    {
        if(Vector3.Distance(transform.position, targetPosition) < 1.0f) {
            waypointIndex++;
            if(waypointIndex == waypoints.Length) {
                waypointIndex = 0;
            }
            targetPosition = waypoints[waypointIndex].transform.position;
        }

        Vector3 direction = transform.position - targetPosition;
        // Quaternion lookTarget = Quaternion.LookRotation(direction, Vector3.forward);
        // Quaternion rotation = Quaternion.Slerp(
        //     transform.rotation, lookTarget, 0.1f);
        // transform.rotation = rotation;
        transform.right = direction;
        transform.position = Vector3.MoveTowards(
            transform.position, targetPosition, Time.deltaTime * 0.5f);
    }
}

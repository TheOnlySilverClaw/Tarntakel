using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public GameObject[] waypoints;
    public float speed = 5f;
    private int waypointIndex;
    private Vector3 targetPosition;
    private Vector3 localScale;

    void Start()
    {
        waypointIndex = 0;
        SetTarget(waypoints[0]);
    }

    void Update()
    {

        UpdateTargetPosition();
        transform.position = Vector3.MoveTowards(
            transform.position, targetPosition, Time.deltaTime * speed);
    }

    void UpdateTargetPosition() {

        if(Vector3.Distance(transform.position, targetPosition) < 1.0f) {
            waypointIndex++;
            if(waypointIndex == waypoints.Length) {
                waypointIndex = 0;
            }
            SetTarget(waypoints[waypointIndex]);
        }
    }

    void SetTarget(GameObject target) {

        targetPosition = target.transform.position;

        Vector3 direction = targetPosition - transform.position;
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

    public void FollowPlayer(GameObject player) {
        Debug.Log("follow player");
        SetTarget(player);
    }

    public void IgnorePlayer() {
        Debug.Log("ignore player");
        SetTarget(waypoints[waypointIndex]);
    }
}

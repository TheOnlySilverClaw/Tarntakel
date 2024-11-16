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

    // Start is called before the first frame update
    void Start()
    {
        waypointIndex = 0;
        SetTarget(waypoints[0]);
    }

    // Update is called once per frame
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
        Debug.Log("direction: " + direction + " magnitude " + direction.magnitude);

        Vector3 localScale = transform.localScale;
        if(direction.x < 0) {
            localScale.x = 1;
            Debug.Log("rotate x");
            transform.Rotate(0f, 0f, 180f);
        }
        if(direction.x > 0){
            Debug.Log("flip x");
            localScale.x = -1;
        }
        transform.localScale =localScale;
    }
}

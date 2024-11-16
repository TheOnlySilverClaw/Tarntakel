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
        localScale = transform.localScale;
        SetTarget(waypoints[0]);
    }

    // Update is called once per frame
    void Update()
    {

        UpdateTargetPosition();
        // Quaternion lookTarget = Quaternion.LookRotation(direction, Vector3.forward);
        // Quaternion rotation = Quaternion.Slerp(
        //     transform.rotation, lookTarget, 0.1f);
        // transform.rotation = rotation;
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

        Vector3 direction = transform.position - targetPosition;
        transform.right = direction;

        if(direction.y > 0) {
            Vector3 flipped = new Vector3(localScale.x, -localScale.y, localScale.z);
            transform.localScale = flipped;
        }
    }
}

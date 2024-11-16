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

        Vector3 localScale;
        
        if(direction.x > 0) {
            localScale = transform.localScale;
            Debug.Log("flip x");
            transform.Rotate(new Vector3(0, 180, 0));
            // Vector3 flipped = new Vector3(-localScale.x, localScale.y, localScale.z);
            // transform.localScale = flipped;
        }

        // localScale = transform.localScale;
        // if(direction.y > 0) {
        //     Debug.Log("flip y");
        //     Vector3 flipped = new Vector3(localScale.x, -localScale.y, localScale.z);
        //     transform.localScale = flipped;
        // }
    }
}

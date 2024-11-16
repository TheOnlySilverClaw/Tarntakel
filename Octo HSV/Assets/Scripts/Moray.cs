using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moray : MonoBehaviour
{
    public GameObject home;
    public float speed = 7f;

    private Vector3 targetPosition;

    void Start()
    {
        SetTarget(home);
    }

    void Update()
    {

        if(Vector3.Distance(transform.position, targetPosition) > 1.0f) {
            transform.position = Vector3.MoveTowards(
                transform.position, targetPosition, Time.deltaTime * speed);
        }
    }

    void SetTarget(GameObject target) {
        targetPosition = target.transform.position;
    }

    public void FollowPlayer(GameObject player) {
        Debug.Log("follow player " + player.transform.position);
        SetTarget(player);
    }

    public void IgnorePlayer() {
        Debug.Log("ignore player");
        SetTarget(home);
    }
}

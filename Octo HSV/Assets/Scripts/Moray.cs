using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moray : MonoBehaviour
{
    public GameObject home;
    public float speed = 7f;

    private GameObject target;

    void Start()
    {
        SetTarget(home);
    }

    void Update()
    {

        Vector3 targetPosition = target.transform.position;
        float distance = Vector3.Distance(transform.position, targetPosition);

        if(target == home) {    
            if(distance > 2.5f) {
                transform.position = Vector3.MoveTowards(
                    transform.position, targetPosition, Time.deltaTime * speed);
            } else {
                transform.position = home.transform.position;
                SetDirection(new Vector3(1.0f, -0.2f, 0.0f));
            }
        } else if(distance > 2.5f) {
            transform.position = Vector3.MoveTowards(
                transform.position, targetPosition, Time.deltaTime * speed);
        }
    }

    void SetTarget(GameObject target) {

        this.target = target;
        SetDirection(transform.position - target.transform.position);
    }

    void SetDirection(Vector3 direction) {

        transform.right = direction * -1;

        Vector3 localScale = transform.localScale;
        if(direction.x > 0) {
            localScale.x = 1;
            transform.Rotate(0f, 0f, 180f);
        }
        if(direction.x < 0){
            localScale.x = -1;
        }
        transform.localScale = localScale;
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

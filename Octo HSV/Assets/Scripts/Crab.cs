using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crab : MonoBehaviour
{
    public float speed = 2f;
    public float rightLimit;
    public float leftLimit;
    bool moveRight;

    void Start()
    {
        moveRight = Random.value < 0.5;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("crab x " + transform.position.x);

        if(transform.position.x > rightLimit) {
            moveRight = false;
        } else if(transform.position.x < leftLimit) {
            moveRight = true;
        }
        Debug.Log("move right: " + moveRight);
        transform.position += Vector3.right * Time.deltaTime * (moveRight ? speed : -speed);
    }
}

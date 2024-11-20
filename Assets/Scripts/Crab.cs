using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crab : MonoBehaviour
{
    public float speed = 2f;
    public GameObject rightLimit;
    public GameObject leftLimit;
    bool moveRight;

    void Start()
    {
        moveRight = Random.value < 0.5;
    }

    // Update is called once per frame
    void Update()
    {
        if(rightLimit == null ||  leftLimit == null)
        {
            return;
        }
        if(transform.position.x > rightLimit.transform.position.x) {
            moveRight = false;
        } else if(transform.position.x < leftLimit.transform.position.x) {
            moveRight = true;
        }
        float directedSpeed = (moveRight ? speed : -speed);
        transform.position += Vector3.right * Time.deltaTime * directedSpeed;
    }
}

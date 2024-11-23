using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using static DirectionHelper;

public class FollowPlayer : MonoBehaviour
{

    [SerializeField]
    float speed;

    GameObject player;

    void FixedUpdate()
    {
        if(player == null) return;

        Vector3 playerPosition = player.transform.position;

        transform.position = Vector3.MoveTowards(
            transform.position, playerPosition, Time.deltaTime * speed);
        
        Vector2 direction = playerPosition - transform.position;
        transform.TurnTowards(direction);
    }

    void OnPlayerDetected(GameObject player)
    {
        this.player = player;
    }

    void OnPlayerLost()
    {
        this.player = null;
    }
}

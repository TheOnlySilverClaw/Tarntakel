using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClawAttack : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D collision) {
        
        GameObject target = collision.gameObject;
        if(target.tag == "Player") {
            target.SendMessage("Panic", gameObject);
        }
    }
}

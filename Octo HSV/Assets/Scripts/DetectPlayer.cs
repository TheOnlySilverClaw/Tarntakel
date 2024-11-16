using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectPlayer : MonoBehaviour
{
    void OnCollisionStay2D(Collision2D collision) {

        GameObject target = collision.collider.gameObject;
        if(target.tag == "Player") {
            GameObject parent = transform.parent.gameObject;
            parent.SendMessage("SetTarget", target);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectables : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other){
        collected();
    }
    public void collected(){
        Debug.Log("Collectable collected");
    }
}

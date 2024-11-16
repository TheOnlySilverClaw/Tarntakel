using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectables : MonoBehaviour
{
    [SerializeField]
    private ParticleSystem disappearingPart;
    void OnTriggerEnter2D(Collider2D other){
        collected();
    }
    public void collected(){
        Debug.Log("coin collected");
        Destroy(this.gameObject);
        disappearingPart.Play();
        float playTime = disappearingPart.duration + disappearingPart.startLifetime;
        Destroy(disappearingPart.transform.parent.gameObject, playTime);
    }
}

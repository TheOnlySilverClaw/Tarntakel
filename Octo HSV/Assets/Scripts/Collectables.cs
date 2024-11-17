using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectables : MonoBehaviour
{
    [SerializeField]
    private ParticleSystem disappearingPart;

    private void Start()
    {
        Exit.Instance.Register();
    }

    void OnTriggerEnter2D(Collider2D other){
        Exit.Instance.Collect();
        collected();
    }

    public void collected(){
        Destroy(this.gameObject);
        disappearingPart.Play();
        float playTime = disappearingPart.duration + disappearingPart.startLifetime;
        Destroy(disappearingPart.transform.parent.gameObject, playTime);
    }
}

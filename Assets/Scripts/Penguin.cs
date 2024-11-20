using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class penguin : MonoBehaviour
{
    public GameObject[] waypoints;
    public float timeBetweenActions;
    private bool waiting;
    private IEnumerator method;
    [SerializeField]
    private AnimationCurve speedRange;
    private float speed = 20;
    public int waypointIndex;
    private GameObject target;
    [SerializeField]
    private ParticleSystem _bubbles;
    
    void Start()
    {
        waypointIndex = 0;
        SetTarget(waypoints[0]);
    }

    void Update()
    {
            if(!waiting){
            UpdateTargetPosition();
            transform.position = Vector3.MoveTowards(
                transform.position, target.transform.position, Time.deltaTime * speed);
            }
    }

    void UpdateTargetPosition() {

        Vector3 targetPosition = target.transform.position;
        if(Vector3.Distance(transform.position, targetPosition) < 1.0f){
            speed = speedRange.Evaluate(waypointIndex);
            if(waypointIndex == waypoints.Length){
                speed = 0;
                method = startPenguinCycle();
                StartCoroutine(method);
                waiting = true;
            }
            if(waypointIndex != waypoints.Length) SetTarget(waypoints[waypointIndex]);
            if(waypointIndex == 0){_bubbles.Play();}
            if(waypointIndex !=0){_bubbles.Stop();}
            waypointIndex++;
        }
    }

    void SetTarget(GameObject target) {

        this.target = target;

        Vector3 direction = target.transform.position - transform.position;
        transform.right = direction;

        Vector3 localScale = transform.localScale;
        if(direction.x < 0) {
            localScale.x = 1;
            transform.Rotate(0f, 0f, 180f);
        }
        if(direction.x > 0){
            localScale.x = -1;
        }
        transform.localScale =localScale;
    }
    public void FollowPlayer(GameObject player) {
        SetTarget(player);
    }

    public void IgnorePlayer() {
        SetTarget(waypoints[waypointIndex]);
    }
   
   private IEnumerator startPenguinCycle(){
        yield return new WaitForSeconds(timeBetweenActions);
        waypointIndex = 0;
        speed = speedRange.Evaluate(waypointIndex);
        waiting = false;
   } 
}

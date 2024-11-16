using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectPlayer : MonoBehaviour
{
    [SerializeField]
    private FloatAttribute _visibility;

    [SerializeField]
    private AnimationCurve _xScale;

    [SerializeField]
    private AnimationCurve _yScale;

    void Update()
    {
        float x = _xScale.Evaluate(_visibility.Value);
        float y = _yScale.Evaluate(_visibility.Value);
        transform.localScale = new Vector3(x, y, 1f);
    }

    void OnTriggerStay2D(Collider2D collider) {

        Debug.Log("trigger " + collider);
        
        GameObject target = collider.gameObject;
        if(target.tag == "Player") {
            GameObject parent = transform.parent.gameObject;
            parent.SendMessage("FollowPlayer", target);
        }
    }

    void OnTriggerExit2D(Collider2D collider) {

        Debug.Log("trigger exit");
        
        GameObject target = collider.gameObject;
        if(target.tag == "Player") {
            GameObject parent = transform.parent.gameObject;
            parent.SendMessage("IgnorePlayer");
        }
    }
}

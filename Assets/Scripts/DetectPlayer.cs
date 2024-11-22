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
        
        GameObject target = collider.gameObject;
        if(target.tag == "Player") {
            GameObject parent = transform.parent.gameObject;
            parent.SendMessage("OnPlayerDetected", target, SendMessageOptions.DontRequireReceiver);
        }
        changeColor(1f);
    }

    void OnTriggerExit2D(Collider2D collider) {

        GameObject target = collider.gameObject;
        if(target.tag == "Player") {
            GameObject parent = transform.parent.gameObject;
            parent.SendMessage("OnPlayerLost", SendMessageOptions.DontRequireReceiver);
        }
        changeColor(0f);
    }
    private void changeColor(float Saturation){
        Color color = gameObject.GetComponent<SpriteRenderer>().color;
        color = Color.HSVToRGB(0f, Saturation, 1f);
        color.a = 0.5f;
        gameObject.GetComponent<SpriteRenderer>().color = color;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideViewCone : MonoBehaviour
{

    [SerializeField]
    Collider2D bodyCollider;

    [SerializeField]
    SpriteRenderer spriteRenderer;

    [SerializeField]
    float hideSpeed = 7.5f;

    bool hiding;

    void FixedUpdate() {

        float change = hideSpeed * Time.deltaTime;

        Color color = spriteRenderer.color;

        if(hiding)
        {
            if(color.a >= 0f)
            {
                color.a = Mathf.Clamp(color.a - change, 0f, 0.5f);

            }
        }
        else
        {
            if(color.a <= 0.5f)
            {
                color.a = Mathf.Clamp(color.a + change, 0f, 0.5f);
            }
        }

        spriteRenderer.color = color;
    }

    void OnTriggerStay2D(Collider2D otherCollider)
    {
        GameObject other = otherCollider.gameObject;
        if(other.tag == "Hideout") {
            Bounds ownBounds = bodyCollider.bounds;
            Bounds otherBounds = otherCollider.bounds;
            // required because z value slightly deviates sometimes? o.ô
            otherBounds.Expand(new Vector3(0f, 0f, 0.5f));
            if(otherBounds.Contains(ownBounds.min) && otherBounds.Contains(ownBounds.max))
            {
                hiding = true;
            }
            else
            {
                hiding = false;
            }
        }
    }
}

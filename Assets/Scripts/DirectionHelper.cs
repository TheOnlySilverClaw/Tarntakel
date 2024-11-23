using UnityEngine;

public static class DirectionHelper {

    public static void TurnTowards(this Transform transform, Vector2 direction)
    {
        float angle = Vector2.SignedAngle(Vector2.up, direction);

        Vector3 localScale = transform.localScale;
        if(angle < 0f)
        {
            localScale.x = -1;
            transform.right = direction;
        }
        else
        {
            localScale.x = 1;
            transform.right = -direction;
        }
        transform.localScale = localScale;
    }
}
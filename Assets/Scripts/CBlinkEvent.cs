using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CBlinkEvent : MonoBehaviour
{
    public LayerMask blockingMask;
    public Transform checkPoint;

    CPlayerMovement movement;
    public float checkRange;

    void Awake()
    {
        movement = GetComponent<CPlayerMovement>();
    }

    public void BlinkEvent()
    {
        Vector2 endPos = new Vector2(checkPoint.position.x - ((movement.isRight) ? -checkRange : checkRange), checkPoint.position.y);
        Collider2D hitCollision = Physics2D.OverlapCircle(endPos, 0.25f, blockingMask);

        Debug.DrawLine(checkPoint.position, endPos, Color.red);

        if (hitCollision != null) return;

        transform.position = endPos;

    }

}

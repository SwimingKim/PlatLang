﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CBlinkEvent : CStageEvent
{
    public Transform checkPoint;

    CPlayerMovement movement;
    public float checkRange;

    void Awake()
    {
        movement = GetComponent<CPlayerMovement>();
    }

    void Start()
    {
        
    }

    public override void StageEvent()
    {
        Vector2 endPos = new Vector2(checkPoint.position.x - ((movement.isRight) ? -checkRange : checkRange), checkPoint.position.y);
        Collider2D hitCollision = Physics2D.OverlapCircle(endPos, 0.25f, 1 <<LayerMask.NameToLayer("BlockingLayer"));

        Debug.DrawLine(checkPoint.position, endPos, Color.red);

        if (hitCollision != null) return;

        transform.position = endPos;
    }

}

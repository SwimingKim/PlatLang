using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CSmashEvent : CStageEvent
{
    public Transform checkPoint;

    public float checkRange;

    CPlayerAnimation _anim;

    void Awake()
    {
        _anim = GetComponent<CPlayerAnimation>();
    }

    void Start()
    {

    }

    // void Update()
    // {
    //     Vector2 endPos = new Vector2(transform.position.x, transform.position.y - 0.5f);
    //     Debug.DrawLine(transform.position, endPos, Color.red);
    // }

    public override void StageEvent()
    {
        _anim.PlayAnimation(CPlayerAnimation.ANIM_TYPE.SMASH);
    }

    public void SmashEvent()
    {
        Vector2 endPos = new Vector2(transform.position.x, transform.position.y - 0.5f);
        RaycastHit2D hit = Physics2D.Linecast(transform.position, endPos, 1 << LayerMask.NameToLayer("BlockingLayer"));
        Debug.DrawLine(transform.position, endPos, Color.red);

        if (hit.collider == null || hit.collider.tag != "Box") return;
		hit.collider.gameObject.GetComponent<CBox>().Destroy();


        transform.position = endPos;
    }

}

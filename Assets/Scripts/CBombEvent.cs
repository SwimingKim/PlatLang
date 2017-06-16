using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CBombEvent : CStageEvent
{

    public Transform bombPos;
    public GameObject thurderItem;

	Vector2 pos;

    void Start()
    {

    }

    public override void StageEvent()
    {
		if (GetPos())
		{
	        Instantiate(thurderItem, pos, Quaternion.identity);
		}
    }

    bool GetPos()
    {
        Vector2 endPos = new Vector2(transform.position.x, transform.position.y - 1.75f);
		RaycastHit2D hit = Physics2D.Linecast(transform.position, endPos, 1 <<LayerMask.NameToLayer("BlockingLayer"));
        Debug.DrawLine(transform.position, endPos, Color.red);

		if (hit.collider == null) return false;

        Collider2D col = hit.collider;
        if (col != null && col.gameObject.tag != "BombBox")
			pos = new Vector2(col.transform.position.x, bombPos.position.y + 0.125f);

		return true;
    }

}

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

        if (hit.collider != null)
			pos = new Vector2(hit.collider.transform.position.x, bombPos.position.y + 0.125f);

		return true;
    }

}

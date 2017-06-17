using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CSpring : MonoBehaviour {

	public void IsJump()
	{
        Vector2 startPos = new Vector2(transform.position.x-0.32f, transform.position.y);
        Vector2 endPos = new Vector2(transform.position.x+0.32f, transform.position.y);
        RaycastHit2D hit = Physics2D.Linecast(startPos, endPos, 1 << LayerMask.NameToLayer("Player"));
        // RaycastHit2D hit = Physics2D.BoxCast(startPos, endPos, 1 << LayerMask.NameToLayer("Player"));
        Debug.DrawLine(startPos, endPos, Color.red);

        if (hit.collider == null) return;
		Debug.Log("충돌?");
		hit.collider.GetComponent<CPlayerMovement>().JumpUp();
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.name == "Gnome")
		{
			other.GetComponent<CPlayerMovement>().JumpUp();
		}
	}

}

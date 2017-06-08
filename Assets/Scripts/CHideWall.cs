using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CHideWall : MonoBehaviour {

	public GameObject player;
	public SpriteRenderer[] spList;

	void Awake()
	{
		spList = GetComponentsInChildren<SpriteRenderer>();
	}

	void FixedUpdate()
	{
		float dis = Vector3.Distance(player.transform.position, transform.position);
		if (dis <= 3f)
		{
			foreach (SpriteRenderer row in spList)
			{
				row.enabled = false;
			}
		}
		else if (dis > 5f)
		{
			foreach (SpriteRenderer row in spList)
			{
				row.enabled = true;
			}
		}
	}

}

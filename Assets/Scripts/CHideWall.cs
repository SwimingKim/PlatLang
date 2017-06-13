using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CHideWall : MonoBehaviour {

	public GameObject player;
	public SpriteRenderer[] spList;

	public float visibleDist = 3f, invisibleDist = 5f;

	void Awake()
	{
		spList = GetComponentsInChildren<SpriteRenderer>();
	}

	void FixedUpdate()
	{
		float dis = Vector3.Distance(player.transform.position, transform.position);
		if (dis <= visibleDist)
		{
			foreach (SpriteRenderer row in spList)
			{
				row.enabled = false;
			}
		}
		else if (dis > invisibleDist)
		{
			foreach (SpriteRenderer row in spList)
			{
				row.enabled = true;
			}
		}
	}

}

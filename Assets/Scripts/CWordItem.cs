using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CWordItem : MonoBehaviour {

	public int order;

	public void Init(int order)
	{
		this.order = order;
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.name == "Gnome")
		{
			Destroy(gameObject);

			other.GetComponent<CPlayerManager>().WordEarnByManager(order);
		}
	}

}

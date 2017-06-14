using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CGnomeBombBox : CBombBox {

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.name == "Gnome")
		{
			StartCoroutine("BombCoroutine");
		}
	}

	
}

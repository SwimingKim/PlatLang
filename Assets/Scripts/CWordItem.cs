using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CWordItem : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.name == "Gnome")
		{
			Destroy(gameObject);

			
		}
	}

}

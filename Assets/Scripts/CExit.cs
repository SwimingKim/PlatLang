using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CExit : MonoBehaviour {

	public CLanguageManager lang;

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.name == "Gnome")
		{
			CGameManager.instance.GameEnd(true);			
		}
	}

}

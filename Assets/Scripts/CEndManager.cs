using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CEndManager : MonoBehaviour {

	public Text wordText;
	public Text starText;

	// Use this for initialization
	void Start () {
		wordText.text = "";
		foreach (string item in CGameManager.instance.words)
		{
			Debug.Log(item);
			wordText.text += item+"\n";
		}
		Debug.Log(CGameManager.instance.starCount);
		starText.text = CGameManager.instance.starCount.ToString();
	}
	
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CEndManager : MonoBehaviour {

	public Text wordText;
	public Text starText;
	public Image[] langImage;

	public Sprite[] engImg;
	public Sprite[] jpImg;
	public Sprite[] chImg;

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

		int lang = CGameManager.instance.lang;
		for (int i = 0; i < langImage.Length; i++)
		{
			if (lang == 0) langImage[i].sprite = engImg[i];
			else if (lang == 1) langImage[i].sprite = chImg[i];
			else langImage[i].sprite = jpImg[i];
		}
	}
	
}

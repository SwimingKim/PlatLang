using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CPlayerManager : MonoBehaviour {

	public GameObject stageManagerObj;

	CLanguageManager langManager;
	[HideInInspector]
	public CStageManager stageManager;

	public int starCount
	{
		get
		{
			return langManager.starCount;
		}
	}

	void Start()
	{
		langManager = stageManagerObj.GetComponent<CLanguageManager>();
		stageManager = stageManagerObj.GetComponent<CStageManager>();
	}

	public void StarUpByManager()
	{
        stageManager.StarCountUp();
	}

	public void WordEarnByManager(int order)
	{
		langManager.EarnWordItem(order);	
	}

}

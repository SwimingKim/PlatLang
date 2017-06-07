using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CPlayerManager : MonoBehaviour {

	public GameObject stageManager;

	public void StarUpByManager()
	{
        stageManager.GetComponent<CStageManager>().StarCountUp();
	}

	public void WordEarnByManager()
	{
		stageManager.GetComponent<CLanguageManager>().EarnWordItem(0);	
	}

	public void ShowWordByManager()
	{
		stageManager.GetComponent<CLanguageManager>().ShowWord(1);
	}

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CPlayerManager : MonoBehaviour {

	public GameObject stageManager;

	public void StarUpByManager()
	{
        stageManager.GetComponent<CStageManager>().StarCountUp();
	}

	public void WordEarnByManager(int order)
	{
		stageManager.GetComponent<CLanguageManager>().EarnWordItem(order);	
		
		stageManager.GetComponent<CLanguageManager>().ShowWord(order);
	}

}

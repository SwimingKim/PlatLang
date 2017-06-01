using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CPlayerManager : MonoBehaviour {

	public CStageManager stageManager;

	public void StarUpByManager()
	{
        stageManager.StarCountUp();
	}

	public void WordEarnByManager()
	{
		
	}

}

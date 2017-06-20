using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CWordItem : MonoBehaviour {

	public CGooglePlayServiceManager googleManager;

	[HideInInspector]
	public int order;

	bool isTrigger = false;

	public void Init(int order)
	{
		this.order = order;
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.name == "Gnome" && !isTrigger)
		{
			isTrigger = true;

			Destroy(gameObject);

			CPlayerManager playManager = other.GetComponent<CPlayerManager>();
			playManager.WordEarnByManager(order);
//			Debug.LogFormat("별 {1} 갱신해야해요?", order, playManager.starCount);
			if (playManager.starCount >= 5)
			{
				googleManager.GooglePlayGamesAchievementAndLeaderboardCheck();
			}
		}
	}

}

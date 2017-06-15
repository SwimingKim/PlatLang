using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GooglePlayGames;
using UnityEngine.SocialPlatforms;
// using GooglePlayGames.BasicApi;

public class CGooglePlayServiceManager : MonoBehaviour {

	GameObject _callback;

	public void GooglePlayActivate(GameObject callback)
	{
		if (callback == null) return;
		_callback = callback;

		PlayGamesPlatform.DebugLogEnabled = true;
		PlayGamesPlatform.Activate();

		Social.localUser.Authenticate(GooglePlayGamesLoginCallBack);
	}

	public void GooglePlayDeActive()
	{
		PlayGamesPlatform play = (PlayGamesPlatform)Social.Active;
		if (play != null)
		{
			play.SignOut();
		}
	}

	void GooglePlayGamesLoginCallBack(bool result)
	{
		if (result)
		{
			_callback.SendMessage("GooglePlayGamesLoginSuccess", Social.Active.localUser.id);
		}
		else
		{
			_callback.SendMessage("GooglePlayGamesLoginFail");
		}
	}

	public void GooglePlayGamesAchievementUI()
	{
		Social.ShowAchievementsUI();
	}

	public void GooglePlayGamesLeaderBoardUI()
	{
		Social.ShowLeaderboardUI();
	}

	public void GooglePlayGamesAchievementAndLeaderboardCheck(CLanguageManager.LANGTYPE lang, int num)
	{
	}



	void AchievementSetCallback(bool result)
	{
	}

	void LeaderBoardScoreSetCallback(bool result)
	{
	}


}

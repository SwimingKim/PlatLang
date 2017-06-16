using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using GooglePlayGames;
using UnityEngine.SocialPlatforms;

public class CLoginManager : MonoBehaviour {

	public CGooglePlayServiceManager _googlePlayManager;

	public Text loginText;
	public Button loginButton;

	void Start()
	{
		if (Social.localUser.authenticated)
		{
			SetUserName();
		}
	}

	public void OnIntroButtonClick()
	{
		if (!Social.localUser.authenticated && Application.platform == RuntimePlatform.Android)
		{
			Debug.Log("안드로이드 출력");
			_googlePlayManager.GooglePlayActivate(gameObject);
			return;		
		}
		CMainManger.instance.FrontMove();

	}

	public void GooglePlayGamesLoginSuccess(string loginId)
	{
		Debug.Log(loginId + " 로그인");

		SetUserName();
	}

	public void GooglePlayGamesLoginFail()
	{
		Debug.Log("로그인 실패");
	}

	void SetUserName()
	{
		loginText.text = Social.localUser.userName + "님으로 시작";
	}

}

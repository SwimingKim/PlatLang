using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SocialPlatforms;

public class CLoginManager : MonoBehaviour {

	public CGooglePlayServiceManager _googlePlayManager;

	public Text loginText;
	public Button loginButton;

	void Start()
	{
		if (Social.localUser.authenticated)
		{
			loginText.text = Social.localUser.userName + "님으로 시작";	
		}
	}

	public void OnIntroButtonClick()
	{
		#if UNITY_ANDROID
		if (!Social.localUser.authenticated)
		{
			_googlePlayManager.GooglePlayActivate(gameObject);
			return;		
		}
		#endif

		CMainManger.instance.FrontMove();
	}

	public void GooglePlayGamesLoginSuccess(string loginId)
	{
		Debug.Log(loginId + " 로그인");

		loginText.text = Social.localUser.userName + "님으로 시작";
	}

	public void GooglePlayGamesLoginFail()
	{
		Debug.Log("로그인 실패");
	}

}

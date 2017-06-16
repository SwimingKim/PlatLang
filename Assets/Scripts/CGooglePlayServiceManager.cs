using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GooglePlayGames;
using UnityEngine.SocialPlatforms;
// using GooglePlayGames.BasicApi;

public class CGooglePlayServiceManager : MonoBehaviour
{

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

    public void GooglePlayGamesAchievementAndLeaderboardCheck()
    {
        Debug.Log("갱신을 시도합니다");
        int lang = CGameManager.instance.lang;
        int stage = CGameManager.instance.stage;
        Debug.Log("갱신정보 lang = "+lang+" stage = "+stage);

		Social.ReportScore(5, CGPGSIds.leaderboard_, LeaderBoardScoreSetCallback);

        switch (lang)
        {
            case 0 :
                if (stage == 1) Social.ReportProgress(CGPGSIds.achievement_attackEng, 100f, AchievementSetCallback);
                else if (stage == 2) Social.ReportProgress(CGPGSIds.achievement_blinkEng, 100f, AchievementSetCallback);
                else if (stage == 3) Social.ReportProgress(CGPGSIds.achievement_bombEng, 100f, AchievementSetCallback);
                else if (stage == 4) Social.ReportProgress(CGPGSIds.achievement_smashEng, 100f, AchievementSetCallback);
                break;
            case 1 :
                if (stage == 1) Social.ReportProgress(CGPGSIds.achievement_attackCh, 100f, AchievementSetCallback);
                else if (stage == 2) Social.ReportProgress(CGPGSIds.achievement_blinkCh, 100f, AchievementSetCallback);
                else if (stage == 3) Social.ReportProgress(CGPGSIds.achievement_bombCh, 100f, AchievementSetCallback);
                else if (stage == 4) Social.ReportProgress(CGPGSIds.achievement_smashCh, 100f, AchievementSetCallback);
                break;
            case 2 :
                if (stage == 1) Social.ReportProgress(CGPGSIds.achievement_attackJp, 100f, AchievementSetCallback);
                else if (stage == 2) Social.ReportProgress(CGPGSIds.achievement_blinkJp, 100f, AchievementSetCallback);
                else if (stage == 3) Social.ReportProgress(CGPGSIds.achievement_bombJp, 100f, AchievementSetCallback);
                else if (stage == 4) Social.ReportProgress(CGPGSIds.achievement_smashJp, 100f, AchievementSetCallback);
                break;
        }
    }

    void AchievementSetCallback(bool result)
    {
    }

    void LeaderBoardScoreSetCallback(bool result)
    {
    }


}

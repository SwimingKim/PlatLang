using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// 게임화면에서 스테이지를 관리하는 클래스
public class CStageManager : MonoBehaviour
{
    public Text starText;

    float backTimer;
    float backDelayTime = 2f;

    void Update()
    {
        backTimer += Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (backTimer >= backDelayTime)
            {
                CGameManager.instance.CallShortToast("\'뒤로\'버튼을 한번 더 누르시면 메인화면으로 갑니다.");
                backTimer = 0f;
            }
            else
            {
                CGameManager.instance.LoadScene(0);
            }
        }
    }

    public void StarCountUp()
    {
        int star = int.Parse(starText.text);
        starText.text = (++star).ToString();
    }

}

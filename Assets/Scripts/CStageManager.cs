using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// 게임화면에서 스테이지를 관리하는 클래스
public class CStageManager : MonoBehaviour
{
    public GameObject player;
    public GameObject eventButton;

    public Text starText;

    public void InputAction(int stage)
    {
        if (stage == 1)
        {
            player.GetComponent<CPlayerAnimation>().PlayAnimation(CPlayerAnimation.ANIM_TYPE.ATTACK);
        }
        else if (stage == 2)
        {
            player.GetComponent<CBlinkEvent>().BlinkEvent();
        }
    }

    public void ShowEventButton()
    {
        eventButton.SetActive(true);
    }

    public void StarCountUp()
    {
        int star = int.Parse(starText.text);
        starText.text = (++star).ToString();
    }

}

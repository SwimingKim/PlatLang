using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// 게임화면에서 스테이지를 관리하는 클래스
public class CStageManager : MonoBehaviour
{
    public Text starText;

    public void StarCountUp()
    {
        int star = int.Parse(starText.text);
        starText.text = (++star).ToString();
    }

}

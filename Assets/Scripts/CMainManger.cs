using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CMainManger : MonoBehaviour
{
    public static CMainManger instance;

    public CIntroCameraMovement cameraMovement;

    public Transform[] _canvas;
    public GameObject[] _stagePanel;
    public GameObject[] _langPanel;
    public Image[] characterImage;

    public int canvasNum = 0;

    // backpress 종료
    float backDelayTime = 2f;
    float backTimer;

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        _langPanel[CGameManager.instance.lang].GetComponent<CLangCanvasClick>().ChangePressed();
    }

    void Update()
    {
        if (canvasNum == 0) backTimer += Time.deltaTime;
        
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            BackMove();
        }
    }

    public void BackMove()
    {
        if (canvasNum == 0)
        {
            if (backTimer >= backDelayTime)
            {
                CGameManager.instance.CallShortToast("\'뒤로\'버튼을 한번 더 누르시면 종료됩니다.");
                Debug.Log("Toast");
                backTimer = 0f;
            }
            else
            {
                Debug.Log("종료");
                Application.Quit();
            }
        }
        else
        {
            if (canvasNum == 1) StageStateReset();
            --canvasNum;
        }

    }

    public void FrontMove()
    {
        canvasNum = (canvasNum >= 2) ? 0 : ++canvasNum;
    }

    public void StageStateReset()
    {
        for (int i = 0; i < _stagePanel.Length; i++)
        {
            _stagePanel[i].GetComponent<CStageCanvasClick>().ChangeNormal();
        }
    }

    public void LangStateReset()
    {
        for (int i = 0; i < _langPanel.Length; i++)
        {
            _langPanel[i].GetComponent<CLangCanvasClick>().ChangeNormal();
        }

    }

    public void StartGame()
    {
        CGameManager.instance.StartStage();
    }

    public Vector3 toCanvasPos()
    {
        return _canvas[canvasNum].position;
    }

}


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CStageCanvasClick : CCanvasClick, ICanvasState
{
    public int index;
    public bool isSelect = false;

    public GameObject _infoPanel;

    public void ChangeNormal()
    {
        gameObject.transform.localScale = new Vector3(1, 1, 1);
        _infoPanel.SetActive(false);
        isSelect = false;
    }

    public void ChangePressed()
    {
        gameObject.transform.localScale = new Vector3(1.25f, 1.25f, 1.25f);
        _infoPanel.SetActive(true);
        isSelect = true;
    }

    public override void ChangeCanvas()
    {
        if (!isSelect)
        {
            CMainManger.instance.StageStateReset();
            ChangePressed();
            CSoundManager.instance._effectSource.Play();
        }
        else
        {
            CGameManager.instance.stage = index;
            Debug.Log("스테이지 = " + index);
            base.ChangeCanvas();
        }
    }
}

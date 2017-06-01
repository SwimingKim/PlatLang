using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CLangCanvasClick : CCanvasClick, ICanvasState
{
    public int index;
    public bool isSelect = false;

    public Sprite[] characterSprite;
    // public Button characteBtn;

    protected override void Start()
    {
        base.Start();
        // characteBtn.onClick.AddListener(() => { ChooseLang(); });
    }

    public void ChangeNormal()
    {
        btn.image.color = btn.colors.highlightedColor;
        isSelect = false;
    }

    public void ChangePressed()
    {
        CMainManger.instance.LangStateReset();

        btn.image.color = btn.colors.pressedColor;
        CMainManger.instance.characterImage[0].sprite = characterSprite[0];
        CMainManger.instance.characterImage[1].sprite = characterSprite[1];
        isSelect = true;
    }

    public override void ChangeCanvas()
    {
        if (!isSelect)
        {
            ChangePressed();
            CSoundManager.instance._effectSource.Play();
            CGameManager.instance.lang = index;
        }
        else
        {
            Debug.Log("언어 = " + index);
            CMainManger.instance.StartGame();
        }
    }

}

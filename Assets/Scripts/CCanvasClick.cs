using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CCanvasClick : MonoBehaviour
{
    protected Button btn;

    protected virtual void Awake()
    {
        btn = gameObject.GetComponent<Button>();
    }

    protected virtual void Start()
    {
        btn.onClick.AddListener(() => ChangeCanvas());
    }

    public virtual void ChangeCanvas()
    {
        Debug.Log(gameObject.name + " 버튼 클릭");
        CMainManger.instance.FrontMove();
    }

}

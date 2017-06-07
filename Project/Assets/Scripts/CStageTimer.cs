using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CStageTimer : MonoBehaviour
{
    public GameObject loadingPanel;
    public bool IsLoading = false;
    public Text loadingText;
    int loadingTime = 0;

    int loadingUpNum = 12;

    protected virtual void Start()
    {
        if (IsLoading)
        {
            loadingPanel.SetActive(true);

            InvokeRepeating("Loading", 0f, 0.1f);
        }
    }

    void Loading()
    {
        if (loadingTime+loadingUpNum >= 100)
        {
            CancelInvoke("Loading");
            IsLoading = false;

            loadingPanel.SetActive(false);
        }
        else
        {
            loadingTime += loadingUpNum;
            loadingText.text = loadingTime + "%";
        }
    }

    void OnDestroy()
    {
        if (CSoundManager.instance != null) CSoundManager.instance._mainSource.Stop();
    }



}

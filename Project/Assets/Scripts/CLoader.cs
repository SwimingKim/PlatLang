using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CLoader : MonoBehaviour
{
    public GameObject _gameManager;
    public GameObject _soundManager;

    void Awake()
    {
        // 스테이지에서 불러오기
        if (SceneManager.GetActiveScene().name != "Main" && CGameManager.instance == null)
        {
            SceneManager.LoadScene("Main");
        }
        else // 메인에서 불러오기
        {
            if (CGameManager.instance == null && _gameManager != null) Instantiate(_gameManager);
            if (CSoundManager.instance == null && _soundManager != null) Instantiate(_soundManager);
            // CGameManager.instance._passMain = true;
        }

    }

}

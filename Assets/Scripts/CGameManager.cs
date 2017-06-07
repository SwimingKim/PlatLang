using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CGameManager : MonoBehaviour
{
    public static CGameManager instance = null;
    
    public int stage;
    public int lang;

    void Awake()
    {
        if (instance == null) instance = this;
        else if (instance != this) Destroy(gameObject);
        DontDestroyOnLoad(gameObject);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha0)) LoadScene(0);        
        if (Input.GetKeyDown(KeyCode.Alpha1)) LoadScene(1);
        if (Input.GetKeyDown(KeyCode.Alpha2)) LoadScene(2);
        if (Input.GetKeyDown(KeyCode.Alpha3)) LoadScene(3);
        if (Input.GetKeyDown(KeyCode.Alpha4)) LoadScene(4);
        if (Input.GetKeyDown(KeyCode.Alpha5)) LoadScene(5);
    }

    public void LoadScene(int SceneNum)
    {
        stage = SceneNum;
        switch (SceneNum)
        {
            case 0: // Main
                SceneManager.LoadScene("Main");
                break;
            case 1: // Attack
                SceneManager.LoadScene("Attack");
                CSoundManager.instance.PlayStart();
                break;
            case 2: // Blink
                SceneManager.LoadScene("Blink");
                CSoundManager.instance.PlayStart();
                break;
            case 3: // Bomb
                SceneManager.LoadScene("Bomb");
                CSoundManager.instance.PlayStart();
                break;
            case 4: // Smash
                SceneManager.LoadScene("Smash");
                CSoundManager.instance.PlayStart();
                break;
            case 5 :
                SceneManager.LoadScene("End");
                break;
        }

    }

    // 메모리 생성 전이면 초기화로 무조건 attack씬에서 시작하므로
    // MainManager의 함수를 활용할 것
    public void StartStage()
    {
        LoadScene(stage+1);
        Debug.Log(stage+1 + "씬 시작");
    }

}

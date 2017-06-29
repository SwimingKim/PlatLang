using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CGameManager : MonoBehaviour
{
    public static CGameManager instance = null;

    CGooglePlayServiceManager googleManager;

    public int stage;
    public int lang;
    public int starCount;
    public int restartStage;

    string package = "com.androidsample.AndroidPlugin";

    public string[] words = new string[5];

    void Awake()
    {
        if (instance == null) instance = this;
        else if (instance != this) Destroy(gameObject);
        DontDestroyOnLoad(gameObject);

        googleManager = GetComponent<CGooglePlayServiceManager>();
    }

    void Start()
    {
        CallSetUnityActivity();
        // 인터넷 연결 상태 확인
        if (Application.internetReachability == NetworkReachability.NotReachable)
        {
            Debug.Log("연결 상태를 확인하세요");
            CallLongToast("연결 상태를 확인해주세요");
        }
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
            case 5:
                SceneManager.LoadScene("End");
                break;
        }
    }

    // 메모리 생성 전이면 초기화로 무조건 attack씬에서 시작하므로
    // MainManager의 함수를 활용할 것
    public void StartStage()
    {
        LoadScene(stage + 1);
        Debug.Log(stage + 1 + "씬 시작");
    }

#if UNITY_ANDROID
    AndroidJavaObject javaObj = null;
    AndroidJavaObject GetJavaObject()
    {
        if (javaObj == null)
        {
            javaObj = new AndroidJavaObject(package);
        }
        return javaObj;
    }

    void CallSetUnityActivity()
    {
        AndroidJavaClass jc = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
        AndroidJavaObject jo = jc.GetStatic<AndroidJavaObject>("currentActivity");
        GetJavaObject().Call("setUnityActivity", jo);
    }

    public void CallShortToast(string strMessage)
    {
        GetJavaObject().Call("showShortToast", strMessage);
    }

    public void CallLongToast(string strMessage)
    {
        GetJavaObject().Call("showLongToast", strMessage);
    }
#endif

}

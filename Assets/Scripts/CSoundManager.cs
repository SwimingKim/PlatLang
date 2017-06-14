using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CSoundManager : MonoBehaviour
{
    public static CSoundManager instance = null;

    public AudioSource _mainSource;
    public AudioSource _effectSource;
    public AudioSource _startSource;

    public bool _isPlayingBGM;

    void Awake()
    {
        if (instance == null) instance = this;
        else if (instance != this) Destroy(gameObject);
        DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
        _isPlayingBGM = PlayerPrefs.GetInt("BGM", 1) == 1 ? true  : false;
        Debug.Log("BGM = "+_isPlayingBGM);
    }

    public void PlayStart()
    {
        _startSource.Play();
    }

    public void PlayEffect()
    {
        _effectSource.Play();
    }

    public void PlayBGM()
    {
        _isPlayingBGM = true;
        if (_mainSource.time == 0)
        {
            _mainSource.Play();
        }
        else
        {
            _mainSource.UnPause();
        }
    }

    public void PauseBGM()
    {
        _isPlayingBGM = false;
        _mainSource.Pause();
    }

    void OnDestroy()
    {
        PlayerPrefs.SetInt("BGM", _isPlayingBGM ? 1 : 0);
    }

    void OnApplicationQuit()
    {
        _mainSource.Stop();
    }

}

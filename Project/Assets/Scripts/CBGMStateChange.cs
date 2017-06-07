using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CBGMStateChange : MonoBehaviour
{
    Image _img;

    public Sprite _normalSprite, _pressedSprite;

    void Awake()
    {
        _img = GetComponent<Image>();
    }

    void Start()
    {
        if (CSoundManager.instance._isPlayingBGM)
        {
			CSoundManager.instance.PlayBGM();
        }
		else
		{
			_img.sprite = _pressedSprite;
		}
    }

    public void ChangeBGMState()
    {
        if (CSoundManager.instance._isPlayingBGM)
        {
            CSoundManager.instance.PauseBGM();
            _img.sprite = _pressedSprite;
        }
        else
        {
            CSoundManager.instance.PlayBGM();
            _img.sprite = _normalSprite;
        }
    }
}

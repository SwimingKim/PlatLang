using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CLanguageManager : MonoBehaviour
{
    public enum LANGTYPE
    {
        ENG, JP, CH
    }
    public LANGTYPE _lang;

    public GameObject _wordPanel;
    public GameObject _studyPanel;

    [HideInInspector]
    public Text _wordText, _koreanText;
    public List<Button> _noOverlaps; // TTS 재생 시 실행 방지
    public Button[] _studyItems; // 습득한 단어 아이템

    Dictionary<string, string> wordData = new Dictionary<string, string>();
    string _wordTxt, _speakTxt, _koreanTxt;

    protected virtual void Awake()
    {
        // GameManager가 없으면 Main으로 가기
        if (CGameManager.instance == null)
        {
            SceneManager.LoadScene("Main");
        }
        else
        {
            Init(CGameManager.instance.lang); // 0 : 영어, 1 : 중국어, 2 : 일본어
        }
    }

    protected void Init(int langMode)
    {
        Debug.Log("Lang Init");

        // 데이터 세팅 (임시)
        ChooseStudyData(langMode);

        // StudyPanel 세팅
        _studyItems = _studyPanel.GetComponentsInChildren<Button>();
        // 단어 학습 전으로 돌리기
        foreach (Button item in _studyItems)
        {
            item.enabled = false;
        }
        Button[] studyButtons = _studyPanel.GetComponentsInChildren<Button>();
        foreach (Button item in studyButtons)
        {
            _noOverlaps.Add(item);
        }

        // WordPanel 세팅
        _wordText = _wordPanel.GetComponentsInChildren<Text>()[0];
        _koreanText = _wordPanel.GetComponentsInChildren<Text>()[1];
        Button[] speakButtons = _wordPanel.GetComponentsInChildren<Button>();
        foreach (Button item in speakButtons)
        {
            _noOverlaps.Add(item);
        }
    }

    // 언어 설정
    void ChooseStudyData(int langMode)
    {
        switch (langMode)
        {
            case 0:
                _lang = LANGTYPE.ENG;
                EasyTTSUtil.Initialize(EasyTTSUtil.UnitedStates);
                wordData["원숭이"] = "Monkey";
                wordData["토끼"] = "Rabit";
                wordData["돌고래"] = "Dolphin";
                wordData["호랑이"] = "Tiger";
                wordData["사슴"] = "Deer";
                break;
            case 1:
                _lang = LANGTYPE.CH;
                EasyTTSUtil.Initialize(EasyTTSUtil.China);
                wordData["원숭이"] = "猴子[hóuzi]";
                wordData["토끼"] = "兔子[tùzi]";
                wordData["돌고래"] = "海豚[hǎitún]";
                wordData["호랑이"] = "老虎[lǎohǔ]";
                wordData["사슴"] = "鹿[lù]";
                break;
            case 2:
                _lang = LANGTYPE.JP;
                EasyTTSUtil.Initialize(EasyTTSUtil.Japan);
                wordData["원숭이"] = "さる[猿]";
                wordData["토끼"] = "うさぎ[兎、兔]";
                wordData["돌고래"] = "いるか[海豚]";
                wordData["호랑이"] = "とら[虎]";
                wordData["사슴"] = "しか[鹿]";
                break;
        }
    }

    public void EarnWordItem(int index)
    {
        _studyItems[0].enabled = true;
        _studyItems[0].image.sprite = _studyItems[0].spriteState.pressedSprite;
    }

    public void ShowWord(int order)
    {
        switch (order)
        {
            case 0:
                _koreanTxt = "원숭이";
                break;
            case 1:
                _koreanTxt = "토끼";
                break;
            case 2:
                _koreanTxt = "돌고래";
                break;
            case 3:
                _koreanTxt = "호랑이";
                break;
            case 4:
                _koreanTxt = "사슴";
                break;
        }

        _wordPanel.SetActive(true);
        if (_lang == LANGTYPE.ENG)
        {
            _koreanText.text = _koreanTxt;
            _speakTxt = _wordText.text = wordData[_koreanTxt];
        }
        else
        {
            _koreanText.text = _koreanTxt;
            _wordText.text = wordData[_koreanTxt];
            _speakTxt = _wordText.text.Split('[')[0];
        }
        Debug.Log(_wordText.text + " : " + _speakTxt);
    }

    public void HideWord()
    {
        _wordPanel.SetActive(false);
        EasyTTSUtil.StopSpeech();
    }

    public void SpeakWord()
    {
        EasyTTSUtil.SpeechFlush(_speakTxt);
        StartCoroutine("PlayTTSCoroutine");
        Debug.Log(_speakTxt + " TTS");
    }

    IEnumerator PlayTTSCoroutine()
    {
        foreach (Button item in _noOverlaps)
        {
            item.enabled = false;
        }

        yield return new WaitForSeconds(3f);

        foreach (Button item in _noOverlaps)
        {
            item.enabled = true;
        }
    }



}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using GameData;

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
    string[] keys = new string[5];
    string _wordTxt, _speakTxt, _koreanTxt;

    string server_lang, server_chapter;

    protected virtual void Awake()
    {
        // GameManager가 없으면 Main으로 가기
        if (CGameManager.instance == null)
        {
            SceneManager.LoadScene("Main");
        }
        else
        {
            Init();
        }
    }

    void Start()
    {
        StartCoroutine("LanguageDataNetCoroutine");
    }

    protected void Init()
    {
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

    public void EarnWordItem(int index)
    {
        _studyItems[index].enabled = true;
        _studyItems[index].image.sprite = _studyItems[0].spriteState.pressedSprite;
    }

    public void ShowWord(int order)
    {
        _koreanTxt = keys[order];

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

        SpeakWord();
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

        yield return new WaitForSeconds(2f);

        HideWord();
        foreach (Button item in _noOverlaps)
        {
            item.enabled = true;
        }
    }

    IEnumerator LanguageDataNetCoroutine()
    {
        string url = "http://skim.kr/platlang.php";

        WWWForm form = new WWWForm();
        form.AddField("lang", ChooseServerLang());
        form.AddField("chapter", ChooseServerChapter());

        WWW www = new WWW(url, form);

        yield return www;

        if (www.error == null)
        {
            Dictionary<string, object> responseData = MiniJSON.jsonDecode(www.text) as Dictionary<string, object>;

            string code = responseData["result_code"].ToString();
            if (!code.Equals("SUCCESS"))
            {
                yield break;
            }

            Dictionary<string, object> dicData = responseData["study"] as Dictionary<string, object>;

            // 랜덤으로 숫자 5개 뽑아오기
            int[] num = ChooseRandomNum(dicData.Count);
            int i = 0;
            foreach (var item in dicData)
            {
                for (int j = 0; j < num.Length; j++)
                {
                    if (num[j] == i)
                    {
                        wordData[item.Key] = item.Value.ToString();
                        keys[j] = item.Key;
                    }
                }
                i++;
            }

            // wordData 출력
            // int k = 0;
            // foreach (KeyValuePair<string, string> kvp in wordData)
            // {
            //     Debug.LogFormat("{2} : Key = {0}, Value = {1}", kvp.Key, kvp.Value, k);
            //     k++;
            // }

        }
        else
        {
            Debug.Log(www.error);
        }
    }

    // 0 : 영어, 1 : 중국어, 2 : 일본어
    string ChooseServerLang()
    {
        int lang = CGameManager.instance.lang;
        switch (lang)
        {
            case 0:
                _lang = LANGTYPE.ENG;
                EasyTTSUtil.Initialize(EasyTTSUtil.UnitedStates);
                return "ENG";
            case 1:
                _lang = LANGTYPE.CH;
                EasyTTSUtil.Initialize(EasyTTSUtil.China);
                return "CH";
            case 2:
                _lang = LANGTYPE.JP;
                EasyTTSUtil.Initialize(EasyTTSUtil.Japan);
                return "JP";
        }
        return "";
    }

    string ChooseServerChapter()
    {
        int stage = CGameManager.instance.stage;
        switch (stage)
        {
            case 1: return "animal";
            case 2: return "weather";
            case 3: return "food";
            case 4: return "color";
        }
        return "";
    }

    // 랜덤으로 5개를 뽑는 함수
    int[] ChooseRandomNum(int size)
    {
        int[] num = new int[5];
        for (int i = 0; i < num.Length; i++)
        {
            num[i] = Random.Range(0, size - 1);
            for (int j = 0; j < i; j++)
            {
                if (num[i] == num[j]) i--;
            }
        }
        return num;
    }

}

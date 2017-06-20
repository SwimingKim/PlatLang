using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CPlayerHealth : MonoBehaviour
{
    // 플레이어 사망 여부
    public bool _isDie = false;
    bool isDamage = false;

    public Image[] _hpImage;
    public int _hpCount = 3;

    Animator _animator;
    CPlayerMovement _movement;
    public CStageManager stageManager;

    public Text[] endText;

    void Awake()
    {
        _animator = GetComponent<Animator>();
        _movement = GetComponent<CPlayerMovement>();
    }

    public void HpDown()
    {
        if (isDamage) return;

        StartCoroutine("HpDownCorountine");
    }

    IEnumerator HpDownCorountine()
    {
        isDamage = true;

        // hp Image 감소
        _hpImage[--_hpCount].enabled = false;
        if (_hpCount <= 0)
        {
            Die();
        }
        // Player 피격 효과
        _animator.Play("Damage", 1);
        _movement.JumpAction(300f);

        yield return new WaitForSeconds(3f);
        Debug.Log("피격 코루틴 종료");
        isDamage = false;
        _animator.Play("Empty");
    }

    public void Die()
    {
        _isDie = true;
        StartCoroutine("GameEndCorountine", false);
    }

    public void GameEnd(bool isWin)
    {
        StartCoroutine("GameEndCorountine", true);
    }

    IEnumerator GameEndCorountine(bool isWin)
    {
        foreach (Text item in endText)
        {
            item.enabled = true;
            item.text = "도전 " + (isWin ? "성공" : "패배");
        }
        CGameManager.instance.starCount = int.Parse(stageManager.starText.text);
        yield return new WaitForSeconds(0.8f);

        CGameManager.instance.LoadScene(5);
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.name == "DeathZone")
        {
            StartCoroutine("GameEndCorountine", false);
        }
    }


}

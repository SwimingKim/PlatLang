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

    void Awake()
    {
        _animator = GetComponent<Animator>();
        _movement = GetComponent<CPlayerMovement>();
    }

    public void HpDown()
    {
        if (isDamage) return;

		Debug.Log("피격");
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
		Debug.Log("코루틴 종료");
		isDamage = false;
		_animator.Play("Empty");
    }

    public void Die()
    {
        _isDie = true;

        GetComponent<BoxCollider2D>().enabled = false;

        _animator.SetTrigger("Die");


		Invoke("GameEnd", 3f);
    }

	void GameEnd()
	{
		// End Scene으로 보냄
		CGameManager.instance.LoadScene(5);
	}


}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CPlayerHealth : MonoBehaviour {
	// 플레이어 사망 여부
	public bool _isDie = false;

	public Image[] _hpImage;
	public int _hpCount = 3;

	public Animator _animator;

	public void HpDown()
	{
		_hpImage[--_hpCount].enabled = false;

		if (_hpCount <= 0)
		{
			Die();
		}
	}

	public void Die()
	{
		_isDie = true;

		GetComponent<BoxCollider2D>().enabled = false;

		_animator.SetTrigger("Die");
	}

	void DieAnimComplete()
	{
		
	}



}

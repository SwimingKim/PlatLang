using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CPlayerAnimation : MonoBehaviour {

	public enum ANIM_TYPE
	{
		IDLE, WALK, JUMP, ATTACK, SMASH
	}
	public ANIM_TYPE _animType = ANIM_TYPE.IDLE;

	Animator _animator;

	void Awake()
	{
		_animator = GetComponent<Animator>();
	}

	public void PlayAnimation(ANIM_TYPE animType)
	{
		_animType = animType;

		switch (animType)
		{
			case ANIM_TYPE.ATTACK :
				_animator.SetTrigger("Attack");
				break;
			case ANIM_TYPE.JUMP :
				_animator.SetTrigger("Jump");
				break;
		}
	}

	public void HorizontalSetting(float num)
	{
		_animator.SetFloat("Horizontal", num);

		if (num > 0) _animator.SetBool("IsRight", true);
		else if (num < 0) _animator.SetBool("IsRight", false);
	}

	public void GroundSetting(bool state)
	{
		_animator.SetBool("IsGround", state);
	}


}

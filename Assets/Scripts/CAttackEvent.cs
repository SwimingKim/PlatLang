using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CAttackEvent : CStageEvent {

	public Transform genPos;
    public GameObject diamondrefab;

	CPlayerAnimation _anim;

	void Awake()
	{
		_anim = GetComponent<CPlayerAnimation>();
	}

	void Start()
	{
		
	}

    public override void StageEvent()
    {
		_anim.PlayAnimation(CPlayerAnimation.ANIM_TYPE.ATTACK);
    }

	public void AttackEvent()
	{
        GameObject diamond = Instantiate(diamondrefab, genPos.position, Quaternion.identity);

        diamond.GetComponent<CDiamond>().Init(GetComponent<Animator>().GetBool("IsRight"));
	}

}

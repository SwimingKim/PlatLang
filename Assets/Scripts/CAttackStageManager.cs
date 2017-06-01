using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CAttackStageManager : CStageManager
{
	protected override void Awake()
	{
		base.Awake();
	}

    protected override void Start()
    {
        base.Start();
    }

    public override void InputAction()
    {
        player.GetComponent<CPlayerAnimation>().PlayAnimation(CPlayerAnimation.ANIM_TYPE.ATTACK);
    }

}

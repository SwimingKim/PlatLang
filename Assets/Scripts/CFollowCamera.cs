using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CFollowCamera : MonoBehaviour {

	public CStageTimer stageTimer;

	public Transform _targetPlayer;
	public Vector3 _offset;
	public float _smoothValue;

	void FixedUpdate()
	{
		if (!stageTimer.IsLoading && _targetPlayer)
		{
			Vector3 targetPos = new Vector3(_targetPlayer.position.x, _targetPlayer.position.y, transform.position.z);


			transform.position = Vector3.Lerp(transform.position, targetPos + _offset, _smoothValue);
		}
	}

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CFollowCamera : MonoBehaviour {

	public CStageTimer stageTimer;
	public Transform _targetPlayer;

	public float xMargin = 1f;
	public float yMargin = 1f;
	public float xSmooth = 2f;
	public float ySmooth = 2f;
	public float maxY = 5f;
	public float minY = -0.5f;

	private float targetX, targetY;

	void FixedUpdate()
	{
		if (!stageTimer.IsLoading && _targetPlayer)
		{
			TrackPlayer();
		}
	}

	bool CheckXMargin()
	{
		return Mathf.Abs(transform.position.x - _targetPlayer.position.x) > xMargin;
	}

	bool CheckYMargin()
	{
		return Mathf.Abs(transform.position.y - _targetPlayer.position.y) > yMargin;
	}

	void TrackPlayer()
	{
		targetX = transform.position.x;
		targetY = transform.position.y;

		if (CheckXMargin())
		{
			targetX = Mathf.Lerp(transform.position.x, _targetPlayer.position.x, xSmooth * Time.deltaTime);
		}

		if (CheckYMargin())
		{
			targetY = Mathf.Lerp(transform.position.y, _targetPlayer.position.y, ySmooth * Time.deltaTime);
		}

		targetY = Mathf.Clamp(targetY, minY, maxY);

		transform.position = new Vector3(targetX, targetY, transform.position.z);
	}

}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CFollowCamera : MonoBehaviour
{
    public CStageTimer stageTimer;
    public Transform _targetPlayer;

    public float xMargin = 0.5f, yMargin = 0.4f;
    public float xSmooth = 3f, ySmooth = 5f;
    public float maxY, minY;

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
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CPlayerMovement : MonoBehaviour
{
    public float _speed;
    float h;

    public bool isJump = false;

    CPlayerAnimation _anim;

    Rigidbody2D _rigidbody2d;
    Animator _animator;
    public SpriteRenderer[] _spriteRender;

    public CStageManager stageManager;

    void Awake()
    {
        _rigidbody2d = GetComponent<Rigidbody2D>();
        _anim = GetComponent<CPlayerAnimation>();
    }

    void Update()
    {
        // 에디터 상에서 확인
        if (Input.GetKeyDown(KeyCode.A)) PressKey(1);
        else if (Input.GetKeyDown(KeyCode.S)) PressKey(2);
        else if (Input.GetKeyDown(KeyCode.D)) PressKey(3);
        else if (Input.GetKeyDown(KeyCode.F)) PressKey(4);
        if (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.S)) StopMove();

        InputMove();
    }

    public void PressKey(int nKey)
    {
        switch (nKey)
        {
            case 1: //left
                h = -1;
                break;
            case 2: //right
                h = 1;
                break;
            case 3: //up
                InputJump();
                break;
            case 4: //down
                stageManager.InputAction();
                break;
        }
    }

    public void InputJump()
    {
        Debug.Log(isJump);
        if (!isJump)
        {
            _anim.PlayAnimation(CPlayerAnimation.ANIM_TYPE.JUMP);
            _rigidbody2d.velocity = new Vector2(_rigidbody2d.velocity.x, 0f);
            _rigidbody2d.AddForce(Vector2.up * 600f);

            isJump = true;
        }
    }

    public void InputMove()
    {
        if (Mathf.Abs(h) > 0)
        {
            for (int i = 0; i < _spriteRender.Length; i++)
            {
                _spriteRender[i].flipX = (Mathf.Sign(h) == 1) ? true : false;
            }
        }

        _anim.HorizontalSetting(h);

        _rigidbody2d.velocity = new Vector2(h * _speed, _rigidbody2d.velocity.y);

    }

    public void StopMove()
    {
        h = 0;
        _rigidbody2d.velocity = Vector2.zero;
    }

    void OnApplicationQuit()
    {
        transform.Translate(Vector2.zero);
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.name == "Event")
        {
            stageManager.ShowEventButton();
            Destroy(other.gameObject);
        }
    }

    void OnCollisionStay2D(Collision2D other)
    {
        if (other.gameObject.tag == "Ground" || other.gameObject.tag == "Box")
        {
            _anim.GroundSetting(true);

            isJump = false;
        }
    }

    void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.tag == "Ground" ||
        other.gameObject.tag == "Box")
        {
            _anim.GroundSetting(false);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Box")
        {
            Destroy(other.gameObject);
        }
    }

}
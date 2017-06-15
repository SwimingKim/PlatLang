using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CPlayerMovement : MonoBehaviour
{
    // 이동
    Rigidbody2D _rigidbody2d;
    float _speed = 2f;
    float h;
    // 점프
    bool isJump = false;
    float jumpPower = 700f;
    // 땅 접촉
    private bool isGround = false;
    public Transform groundCheck;
    // Flip
    public SpriteRenderer[] _spriteRender;
    [HideInInspector]
    public bool isRight = false;
    public Collider2D[] leftCol, rightCol;

    float actionDelayTime = 0.8f;
    float actionTimer;

    // 애니메이션
    CPlayerAnimation _anim;
    // stage
    public GameObject eventButton;
    CStageEvent stageEvent;

    void Awake()
    {
        _rigidbody2d = GetComponent<Rigidbody2D>();
        _anim = GetComponent<CPlayerAnimation>();

        if (CGameManager.instance != null)
        {
            int stage = CGameManager.instance.stage;
            if (stage == 2)
            {
                stageEvent = GetComponent<CBlinkEvent>();
                stageEvent.enabled = true;
            }
            else if (stage == 3)
            {
                stageEvent = GetComponent<CBombEvent>();
                stageEvent.enabled = true;
            }
        }
    }

    void Start()
    {
        Flip();
    }

    void Update()
    {
        actionTimer += Time.deltaTime;

        // 에디터 상에서 확인
        if (Input.GetKeyDown(KeyCode.LeftArrow)) PressKey(1);
        else if (Input.GetKeyDown(KeyCode.RightArrow)) PressKey(2);
        else if (Input.GetKeyDown(KeyCode.Z)) PressKey(3);
        else if (Input.GetKeyDown(KeyCode.X)) PressKey(4);
        if (Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.RightArrow)) StopMove();

        // 땅에 접촉하는지 체크
        isGround = CheckGround();
    }

    void FixedUpdate()
    {
        MoveAction();

        if (isJump)
        {
            JumpAction(this.jumpPower);
        }
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
            case 3:
                if (isGround) isJump = true;
                break;
            case 4:
                if (actionTimer >= actionDelayTime)
                {
                    InputAction(CGameManager.instance.stage);

                    actionTimer = 0f;
                }
                break;
        }
    }

    public void JumpAction(float jumpPower)
    {
        isJump = false;

        _anim.PlayAnimation(CPlayerAnimation.ANIM_TYPE.JUMP);
        _rigidbody2d.velocity = new Vector2(_rigidbody2d.velocity.x, 0f);
        _rigidbody2d.AddForce(Vector2.up * jumpPower);

        _anim.GroundSetting(true);
    }

    public void MoveAction()
    {
        if (h > 0 && !isRight || h < 0 && isRight)
        {
            Flip();
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
        if (other.gameObject.name == "EventItem")
        {
            eventButton.SetActive(true);
            Destroy(other.gameObject);
        }
    }

    bool CheckGround()
    {
        // Vector2 pos = new Vector2(groundCheck.position.x, groundCheck.position.y-0.125f);
        // Debug.DrawLine(groundCheck.position, pos, Color.red);
        return Physics2D.OverlapCircle(groundCheck.position, 0.25f, 1 << LayerMask.NameToLayer("BlockingLayer"));
    }

    void Flip()
    {
        isRight = !isRight;
        for (int i = 0; i < _spriteRender.Length; i++)
        {
            _spriteRender[i].flipX = (Mathf.Sign(h) == 1) ? true : false;
        }

        if (isRight)
        {
            foreach (var item in leftCol)
            {
                item.enabled = false;
            }
            foreach (var item in rightCol)
            {
                item.enabled = true;
            }
        }
        else
        {
            foreach (var item in leftCol)
            {
                item.enabled = true;
            }
            foreach (var item in rightCol)
            {
                item.enabled = false;
            }
        }

    }

    void InputAction(int stage)
    {
        switch (stage)
        {
            case 1:
                _anim.PlayAnimation(CPlayerAnimation.ANIM_TYPE.ATTACK);
                break;
            case 2:
            case 3:
                stageEvent.StageEvent();
                break;
            case 4:
                Debug.Log("내리치기");
                break;
        }
    }

}
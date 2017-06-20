using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CMonsterMovement : MonoBehaviour
{

    public bool isRightDir = false;
    Rigidbody2D _rigidbody2d;

    public float _moveSpeed;

    public GameObject _parentObj;

    void Awake()
    {
        _rigidbody2d = GetComponent<Rigidbody2D>();
    }

	void FixedUpdate()
	{
        Move();

		Attacked();
	}

    void Move()
    {
        _rigidbody2d.velocity = new Vector2(isRightDir ? _moveSpeed : -_moveSpeed, _rigidbody2d.velocity.y);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "TurnPoint")
        {
            Flip();
        }
    }

    void Attacked()
    {
        Vector2 startPos = new Vector2(transform.position.x - 0.1f, transform.position.y + 0.2f);
        Vector2 endPos = new Vector2(transform.position.x + 0.15f, transform.position.y + 0.2f);

        Debug.DrawLine(startPos, endPos, Color.blue);

        // Collider2D col = Physics2D.OverlapCircle(startPos, 0.15f, 1 << LayerMask.NameToLayer("Player"));
        RaycastHit2D hit = Physics2D.Linecast(startPos, endPos, 1 << LayerMask.NameToLayer("Player"));
        if (hit.collider != null) Destroy();

    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.name == "Gnome")
        {
            other.gameObject.SendMessage("HpDown");
        }
        else if (other.gameObject.tag == "BombBox")
        {
            Flip();
        }
    }

    void Flip()
    {
        Vector2 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;

        isRightDir = !isRightDir;
    }

    void Destroy()
    {
        Destroy(_parentObj);
    }

}

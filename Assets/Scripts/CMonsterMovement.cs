using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CMonsterMovement : MonoBehaviour {

	public bool isRightDir = false;
	Rigidbody2D _rigidbody2d;

	public float _moveSpeed;

	public GameObject _player;

	void Awake()
	{
		_rigidbody2d = GetComponent<Rigidbody2D>();
	}

	void Update()
	{
		Move();
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

	void Flip()
	{
		Vector2 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
		Debug.Log(transform.localScale);

		isRightDir = !isRightDir;
		Debug.Log("Flip");
	}

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CDiamond : MonoBehaviour {

	public float _dirValue;
	public float _maxSpeed;
	Rigidbody2D _rigidbody2d;

	public GameObject _destroyEffectPrefab;
	public float _destroyEffectDestroyTime;

	public void Init(bool isRightDir)
	{
		_rigidbody2d = GetComponent<Rigidbody2D>();
		_dirValue = (isRightDir) ? 1 : -1;
		
		Move();

		Invoke("Destroy", 1.2f);
	}

	public void Move()
	{
		_rigidbody2d.velocity = new Vector2(_dirValue * _maxSpeed, _rigidbody2d.velocity.y);
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.name == "Box" || other.name == "WordBox")
		{
			other.gameObject.GetComponent<CBox>().Destroy();
			Destroy(gameObject);
		}

		else if (other.name == "Ground" || other.name == "XBox")
		{
			Destroy(gameObject);
		}
		else if (other.tag == "Monster")
		{
			other.SendMessage("Destroy");
			Destroy(gameObject);
		}
	}

	void Destroy()
	{
		Destroy(gameObject);	
	}


}

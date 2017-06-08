using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CPlayerDamage : MonoBehaviour {

	CPlayerHealth _health;
	Animator _animator;
	Transform groundCheck;

	void Start()
	{
		_health = GetComponent<CPlayerHealth>();
	}

	void Update()
	{
	}

	void OnCollisionEnter2D(Collision2D other)
	{
		if (other.gameObject.name == "Needle")
		{
			_health.HpDown();
		}
	}


}

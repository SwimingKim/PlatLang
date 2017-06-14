using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CBombBox : MonoBehaviour {

	Animator animator;

	void Awake()
	{
		animator = GetComponent<Animator>();
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.name == "Gnome")
		{
			animator.SetTrigger("Bomb");

			StartCoroutine("BombCoroutine");
		}
	}

	IEnumerator BombCoroutine()
	{
		yield return new WaitForSeconds(1.5f);

		Collider2D[] hitColliders = Physics2D.OverlapCircleAll(transform.position, 0.5f, 1 <<LayerMask.NameToLayer("BlockingLayer"));

		Debug.Log(hitColliders.Length);
		foreach (Collider2D item in hitColliders)
		{
			if (item.tag == "Box")
			{
				item.SendMessage("Destroy");
			}
		}
	}

	void Destroy()
	{
		Destroy(gameObject);
	}

}

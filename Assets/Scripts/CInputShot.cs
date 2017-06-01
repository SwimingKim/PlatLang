using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CInputShot : MonoBehaviour {

	public Transform genPos;
	public GameObject starPrefab;

	public void Shot()
	{
		GameObject star = Instantiate(starPrefab, genPos.position, Quaternion.identity);

		star.GetComponent<CStar>().Init(GetComponent<Animator>().GetBool("IsRight"));
	}
}

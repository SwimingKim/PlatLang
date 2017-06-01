using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CInputShot : MonoBehaviour {

	public Transform genPos;
	public GameObject diamondrefab;

	public void Shot()
	{
		GameObject diamond = Instantiate(diamondrefab, genPos.position, Quaternion.identity);

		diamond.GetComponent<CDiamond>().Init(GetComponent<Animator>().GetBool("IsRight"));
	}
}

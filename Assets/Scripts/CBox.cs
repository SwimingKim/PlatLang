using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CBox : MonoBehaviour
{
    public GameObject itemPrefab;

	public bool isRandom;

    public virtual void Destroy()
    {
        Destroy(gameObject);

        // 30% 확률로 아이템 드랍
        if (isRandom && Random.Range(1, 10) < 3) ItemDrop();
		else if (!isRandom) ItemDrop();
    }

    protected void ItemDrop()
    {
        Instantiate(itemPrefab, transform.position, Quaternion.identity);
    }

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.name == "Gnome")
		{
			Destroy();
		}
	}

}

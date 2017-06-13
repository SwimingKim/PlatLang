using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CWordBox : CBox {

	public int order;

	protected override void ItemDrop()
	{
		itemPrefab.GetComponent<CWordItem>().Init(order);
		base.ItemDrop();
	}

}

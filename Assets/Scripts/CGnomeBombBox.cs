using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CGnomeBombBox : CBombBox
{
    void Start()
    {
        SetBomb();
    }

    protected override void SetBomb()
    {
        StartCoroutine("BombCoroutine");
    }

}

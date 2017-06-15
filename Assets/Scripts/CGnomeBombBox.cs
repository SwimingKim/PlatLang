using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CGnomeBombBox : CBombBox
{

    protected override void SetBomb()
    {
        StartCoroutine("BombCoroutine");
    }

}

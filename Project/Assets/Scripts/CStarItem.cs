using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CStarItem : MonoBehaviour
{

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == "Gnome")
        {
            Destroy(gameObject);

            other.GetComponent<CPlayerManager>().StarUpByManager();
        }
    }


}

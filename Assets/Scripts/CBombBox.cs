using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CBombBox : MonoBehaviour
{

    Animator animator;

    void Awake()
    {
        animator = GetComponent<Animator>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "Gnome")
        {
            SetBomb();   
        }
    }

    protected IEnumerator BombCoroutine()
    {
        yield return new WaitForSeconds(1.5f);

        Collider2D[] hitColliders = Physics2D.OverlapCircleAll(transform.position, 0.5f, 1 << LayerMask.NameToLayer("BlockingLayer"));

        foreach (Collider2D item in hitColliders)
        {
            if (item.tag == "Box")
            {
                item.SendMessage("Destroy");
            }
            else if (item.tag == "BombBox")
            {
                item.SendMessage("SetBomb");
            }
        }

        Vector2 startMon = new Vector2(transform.position.x - 0.6f, transform.position.y-0.2f);
        Vector2 endMon = new Vector2(transform.position.x + 0.6f, transform.position.y-0.2f);
        RaycastHit2D monCol = Physics2D.Linecast(startMon, endMon, 1<<LayerMask.NameToLayer("Monster"));
        if (monCol.collider != null) Destroy(monCol.collider.gameObject);

        Destroy(gameObject);
    }

    protected virtual void Destroy()
    {
        Destroy(gameObject);
    }

    protected virtual void SetBomb()
    {
        animator.SetTrigger("Bomb");

        StartCoroutine("BombCoroutine");
    }

}

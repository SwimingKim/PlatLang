using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CCameraMovement : MonoBehaviour
{
    float _touchFos = 5f;
    Rigidbody2D _rigidBody;
    float h, v;

    void Awake()
    {
        _rigidBody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Vector2 direction = new Vector2(h, v);
        _rigidBody.AddForce(direction * _touchFos);
    }

    public void PressKey(int nKey)
    {
        switch (nKey)
        {
            case 1: //left
                h = -1;
                break;
            case 2: //right
                h = 1;
                break;
            case 3: //up
                v = 1;
                break;
            case 4: //down
                v = -1;
                break;
        }
    }

    public void StopMove()
    {
        h = v = 0;
        _rigidBody.velocity = Vector2.zero; 
    }

}

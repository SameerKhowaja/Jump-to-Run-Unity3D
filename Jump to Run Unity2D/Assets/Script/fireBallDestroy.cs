using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fireBallDestroy : MonoBehaviour
{
    private void Start()
    {
        Destroy(gameObject, 1f);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.tag == "Ground")
        {
            Destroy(gameObject);
        }

        if (collision.collider.tag == "enemy")
        {
            Destroy(gameObject);
        }
    }
}

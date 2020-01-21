using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroyEnemy : MonoBehaviour
{
    public Rigidbody2D rbEnemy;

    void Update()
    {
        if(transform.position.y < -2.5f)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "fire")
        {
            Destroy(gameObject);
        }

        if (collision.collider.tag == "Player")
        {
            rbEnemy.constraints = RigidbodyConstraints2D.FreezeAll;
        }
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class desroyCoin : MonoBehaviour
{
    Transform player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void Update()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;

        if (transform.position.x + 10f <= player.position.x)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Player")
        {
            Destroy(gameObject);
        }
    }
}

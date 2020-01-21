using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroyGround : MonoBehaviour
{
    Transform player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;

        if (transform.position.x + 10f <= player.position.x)
        {
            Destroy(gameObject);
        }

    }
}

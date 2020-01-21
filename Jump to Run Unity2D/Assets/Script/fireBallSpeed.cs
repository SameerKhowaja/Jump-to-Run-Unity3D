using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fireBallSpeed : MonoBehaviour
{
    public Rigidbody2D rb;
    float speed = 10f;
    void Update()
    {
        rb.velocity = new Vector2(speed, rb.velocity.y);
    }
}

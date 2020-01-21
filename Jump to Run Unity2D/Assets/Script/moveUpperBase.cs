using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveUpperBase : MonoBehaviour
{
    public Rigidbody2D rb;
    Vector2 position, new_position;
    Vector2 Distance;
    float speed;
    float minDistance, maxDistance;
    public bool right;

    void Start()
    {
        position = transform.position;
        Distance = new Vector2(1.53f, 1.72f);
        
        maxDistance = position.x + 1.72f;
        minDistance = position.x - 1.53f;
        right = true;
    }

    void Update()
    {
        speed = Random.Range(0.01f, 0.05f);
        //Debug.Log(transform.position.x); NOT WORKING
        if (transform.position.x < maxDistance && right==true)
        {
            new_position = new Vector2(maxDistance, transform.position.y);
            transform.position = Vector2.MoveTowards(transform.position, new_position, speed);
        }
        if (transform.position.x >= new_position.x)
        {
            right=false;
        }

        if(right==false && transform.position.x > minDistance)
        {
            new_position = new Vector2(minDistance, transform.position.y);
            transform.position = Vector2.MoveTowards(transform.position, new_position, speed);
        }
        if (transform.position.x <= minDistance)
        {
            right=true;
        }

    }
}

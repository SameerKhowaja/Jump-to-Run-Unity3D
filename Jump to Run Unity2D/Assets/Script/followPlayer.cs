using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class followPlayer : MonoBehaviour
{
    public Transform player;
    public float YPos;

    void Update()
    {
        transform.position = new Vector3(player.position.x + 5f, YPos, -10f);
    }
}

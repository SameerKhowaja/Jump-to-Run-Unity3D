using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseSpawnner : MonoBehaviour
{
    public GameObject[] Base;
    public GameObject UpperBase;
    public GameObject[] Enemy;
    public GameObject coin;

    float StartTime;
    float SpawnTime;
    Vector3 Position;
    Vector3 New_Position;
    Vector3 Enemy_Position;
    Vector3 UpperBase_Position;
    Vector3 coin_Position;

    float destroyTime;

    int RandomBaseSelect;
    float RandomBaseDifference;
    int Enemy_YesNO;
    int Coin_YesNO;
    int UpperBase_YesNo;

    void Start()
    {
        StartTime = 0.5f;
        SpawnTime = 1f;

        Position = new Vector3(-1.7f, -2.3f, 0f);
        Instantiate(Base[0], Position, Quaternion.identity);
    }

    void Update()
    {
        if (Time.time > StartTime)
        {
            RandomBaseSelect = Random.Range(0, 3);
            if(RandomBaseSelect == 0 || RandomBaseSelect == 1)
            {
                RandomBaseDifference = Random.Range(7.6f, 8.9f);
            }
            else
            {
                RandomBaseDifference = Random.Range(8.9f, 10.1f);
            }

            New_Position = Position + new Vector3(RandomBaseDifference, 0f, 0f);
            Position = New_Position;
            Instantiate(Base[RandomBaseSelect], Position, Quaternion.identity);

            Enemy_YesNO = Random.Range(0, 2);
            Coin_YesNO = Random.Range(0, 4);
            if(Coin_YesNO == 1)
            {
                coin_Position = new Vector3(Position.x + 4f, Position.y + 3.3f, 0f);
                Instantiate(coin, coin_Position, Quaternion.identity);
                Enemy_YesNO = 0;
            }

            float xEnemyRandom = Random.Range(-2.1f, 2.2f);
            Enemy_Position = new Vector3(Position.x + xEnemyRandom, -1.45f, 0f);
            if (Enemy_YesNO == 1)
            {
                int RandomEnemy = Random.Range(0, 3);
                xEnemyRandom = Random.Range(-2.1f, 2.2f);
                Instantiate(Enemy[RandomEnemy], Enemy_Position, Quaternion.identity);
            }

            UpperBase_YesNo = Random.Range(0, 2);
            if (UpperBase_YesNo == 1)
            {
                UpperBase_Position = new Vector3(Position.x, 0.1f, 0f);
                Instantiate(UpperBase, UpperBase_Position, Quaternion.identity);
            }

            StartTime = Time.time + SpawnTime;
        }

    }


}

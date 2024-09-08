using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public float score;
    public GameObject[] enemys;

    public int health = 100;

    void Update()
    {
        Debug.Log($"Score: {score}");    

        enemys = GameObject.FindGameObjectsWithTag("obj3");

        if(health <=0 )
        {
            for (int i = 0; i < enemys.Length; i++)
            {
                Destroy(enemys[i].gameObject);
            }
        }
    }
}

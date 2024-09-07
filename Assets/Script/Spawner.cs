using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public float timer;
    public float timeSetter;
    public GameObject[] objectsToSpawn;
    
    void Start()
    {
        timer = timeSetter;
    }

    void Update()
    {
        timer -= Time.deltaTime;

        if (timer <= 0)
        {
            timeSetter = Random.Range(2f, 10f);
            int objectIndex = Random.Range(0,4);
            GameObject spawnedObject = Instantiate(objectsToSpawn[objectIndex], transform.position, Quaternion.identity);
            timer = timeSetter;
        }
    }
}

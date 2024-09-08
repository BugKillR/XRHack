using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ballSpawner : MonoBehaviour
{
    public GameObject[] ballPrefab; // Top prefab'ı buraya atanacak
    public Transform spawnPoint; // Topun spawn edileceği nokta

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Ball"))
        {
            return; // Eğer alanda zaten top varsa, hiçbir şey yapma
        }

        CreateBall();
    }

    private void CreateBall()
    {
        if (ballPrefab != null && spawnPoint != null)
        {
            int randBall = Random.Range(0,ballPrefab.Length +1);
            GameObject spawnedObj = ballPrefab[randBall];
            Instantiate(spawnedObj, spawnPoint.position, Quaternion.identity);
        }
    }
}

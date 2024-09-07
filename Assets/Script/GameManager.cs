using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public float score;

    public int health = 100;

    void Update()
    {
        Debug.Log($"Score: {score}");    
    }
}

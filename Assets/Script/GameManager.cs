using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public float score;

    void Update()
    {
        Debug.Log($"Score: {score}");    
    }
}

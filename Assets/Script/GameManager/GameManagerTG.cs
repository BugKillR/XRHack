using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerTG : MonoBehaviour
{
    public int score, time;

    private void Update()
    {
        Debug.Log($"Score: {score}");
        Debug.Log($"\nTime: {time}");
    }
}

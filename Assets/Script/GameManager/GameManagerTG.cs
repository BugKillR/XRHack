using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManagerTG : MonoBehaviour
{
    public int score, time;

    private float passedTime, totalTime = 60;

    //public Canvas 

    public GameObject text;

    private void Awake()
    {
        Time.timeScale = 0;
    }

    private void Update()
    {
        RotateShyCoconut();

        passedTime = Time.time;

        if (0 >= totalTime - passedTime + time)
        {

        }
    }

 private float rotationSpeed = 0.5f;  // Speed of rotation in degrees per frame
private bool rotatingForward = true;  // True means rotating towards 20, false means towards -20

private void RotateShyCoconut()
{
    // Get the current Z rotation in degrees
    float zRotation = text.transform.eulerAngles.z;

    // Ensure the rotation is in the range of -180 to 180 for easier comparison
    if (zRotation > 180) zRotation -= 360;

    // Check rotation limits and adjust the direction accordingly
    if (rotatingForward && zRotation >= 20)
    {
        rotatingForward = false;  // Switch direction to rotate backwards
    }
    else if (!rotatingForward && zRotation <= -20)
    {
        rotatingForward = true;  // Switch direction to rotate forwards
    }

    // Adjust rotation based on the direction
    if (rotatingForward)
    {
        zRotation += rotationSpeed;  // Rotate towards 20
    }
    else
    {
        zRotation -= rotationSpeed;  // Rotate towards -20
    }

    // Apply the new rotation
    text.transform.rotation = Quaternion.Euler(text.transform.eulerAngles.x, text.transform.eulerAngles.y, zRotation);
}


}

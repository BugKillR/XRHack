using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManagerTG : MonoBehaviour
{
    public int score, time;

    private float passedTime, totalTime, startTime = 60;

    private int highScoreInt = 0;

    public GameObject coconut, cocoScore, firstPage, lastPage, inGamePage;

    public TextMeshProUGUI lastScoreText, scoreText, timeText;

    private bool coconutRotatingForward = true;  // For coconut rotation
    private bool cocoScoreRotatingForward = true;  // For cocoScore rotation

    private void Awake()
    {
        Time.timeScale = 0;
    }

    private void Update()
    {
        RotateShyCoconut();

        RotateCocoScore();

        InGameScore();

        passedTime = Time.time;

        totalTime = startTime + time - passedTime;

        totalTime = (int)totalTime;

        if (0 >= startTime - passedTime + time)
        {
            lastPage.SetActive(true);

            inGamePage.SetActive(false);

            Time.timeScale = 0;
        }
    }

private float rotationSpeed = 0.3f;  // Speed of rotation in degrees per frame
private bool rotatingForward = true;  // True means rotating towards 20, false means towards -20

private void RotateShyCoconut()
{
    // Get the current Z rotation in degrees
    float zRotation = coconut.transform.eulerAngles.z;

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
        coconut.transform.rotation = Quaternion.Euler(coconut.transform.eulerAngles.x, coconut.transform.eulerAngles.y, zRotation);
}

    private void RotateCocoScore()
    {

        if(highScoreInt == 0)
        {
            highScoreInt = score;

            lastScoreText.text = $"High Score: {highScoreInt.ToString()}\nScore: {score.ToString()}";
        }
        else if(score > highScoreInt)
        {
            highScoreInt = score;

            lastScoreText.text = $"High Score: {highScoreInt.ToString()}\nScore: {score.ToString()}";
        }
        else
        {
            lastScoreText.text = $"High Score: {highScoreInt.ToString()}\nScore: {score.ToString()}";
        }

        float zRotation = cocoScore.transform.eulerAngles.z;

        if (zRotation > 180) zRotation -= 360;

        if (rotatingForward && zRotation >= 20)
        {
            rotatingForward = false;  
        }
        else if (!rotatingForward && zRotation <= -20)
        {
            rotatingForward = true;  
        }

        if (rotatingForward)
        {
            zRotation += rotationSpeed;  
        }
        else
        {
            zRotation -= rotationSpeed; 
        }

        cocoScore.transform.rotation = Quaternion.Euler(cocoScore.transform.eulerAngles.x, cocoScore.transform.eulerAngles.y, zRotation);
    }

    private void InGameScore()
    {
        scoreText.text = $"Score: {score.ToString()}\nTime: {totalTime.ToString()}";
    }
    public void StartButton()
    {
        Time.timeScale = 1;

        inGamePage.SetActive(true);

        firstPage.SetActive(false);
    }

    public void ReturnMenuButton()
    {
        SceneManager.LoadScene(1);

        inGamePage.SetActive(true);
    }
}

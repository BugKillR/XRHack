using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public GameObject phewPhew, coconutShy, phewButton, coconutButton;

    private float rotationSpeed = 0.1f;  // Speed of rotation in degrees per frame
    private bool rotatingForward = true;  // True means rotating towards 20, false means towards -20

    private AudioSource source;

    private void Awake()
    {
        source = GetComponent<AudioSource>();

        source.loop = true;
    }

    private void Update()
    {
        RotatePhewPhew();
        RotateCoconutShy();  // Now also rotating the coconutShy
    }

    private void RotatePhewPhew()
    {
        // Get the current Z rotation in degrees
        float zRotation = phewPhew.transform.eulerAngles.z;

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
        phewPhew.transform.rotation = Quaternion.Euler(phewPhew.transform.eulerAngles.x, phewPhew.transform.eulerAngles.y, zRotation);
    }

    private void RotateCoconutShy()
    {
        // Get the current Z rotation in degrees
        float zRotation = coconutShy.transform.eulerAngles.z;

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
        coconutShy.transform.rotation = Quaternion.Euler(coconutShy.transform.eulerAngles.x, coconutShy.transform.eulerAngles.y, zRotation);
    }

    public void PhewPhewButton()
    {
        phewButton.GetComponent<AudioSource>().enabled = true;
        StartCoroutine(PhewWait());
    }

    public void CoconutShyButton()
    {
        coconutButton.GetComponent<AudioSource>().enabled = true;
        StartCoroutine(CocoWait());
    }

    private IEnumerator PhewWait()
    {
        yield return new WaitForSeconds(phewButton.GetComponent<AudioSource>().clip.length/3);
        SceneManager.LoadScene(2);
    }

    private IEnumerator CocoWait()
    {
        yield return new WaitForSeconds(coconutButton.GetComponent<AudioSource>().clip.length/3);
        SceneManager.LoadScene(1);
    }

    public void QuitButton()
    {
        Application.Quit();
    }
}
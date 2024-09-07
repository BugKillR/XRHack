using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldenTarget : MonoBehaviour
{
    public GameObject goldenTarget;

    [SerializeField] private float horizontalSpeed, verticalSpeed;

    // Adjust these values according to your scene's boundaries
    private float leftBoundary = -0.5f;
    private float rightBoundary = 9f;
    private float topBoundary = 7.5f;
    private float bottomBoundary = 3.5f;

    private bool isReachedTop = false, isReachedLeft = false;

    private void Start()
    {
        Hide();
    }

    private void FixedUpdate()
    {
        Move();

    }

    private void Move()
    {
        // Check if the target has reached the left or right boundary
        if (transform.position.x <= leftBoundary)
        {
            isReachedLeft = false;
        }
        else if (transform.position.x >= rightBoundary)
        {
            isReachedLeft = true;
        }

        // Check if the target has reached the top or bottom boundary
        if (transform.position.y <= bottomBoundary)
        {
            isReachedTop = false;
        }
        else if (transform.position.y >= topBoundary)
        {
            isReachedTop = true;
        }

        // Move the target based on the current direction
        if (!isReachedTop)
        {
            transform.Translate(Vector3.up * verticalSpeed * Time.deltaTime);
        }
        else
        {
            transform.Translate(Vector3.down * verticalSpeed * Time.deltaTime);
        }

        if (!isReachedLeft)
        {
            transform.Translate(Vector3.left * horizontalSpeed * Time.deltaTime);
        }
        else
        {
            transform.Translate(Vector3.right * horizontalSpeed * Time.deltaTime);
        }
    }

    private void Hide()
    {
        StartCoroutine(Active());
    }

    private IEnumerator Active()
    {
        yield return new WaitForSeconds(5);
        goldenTarget.SetActive(true);
        yield return new WaitForSeconds(5);
        goldenTarget.SetActive(false);
        StartCoroutine(Active());
    }
}


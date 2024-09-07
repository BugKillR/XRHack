using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class Targett : MonoBehaviour
{

    private bool didHit = false, isMovingLeft = true;

    public static int score = 0;

    public static int time = 0;

    private bool reset = true;

    private Vector3 firstLocation;

    [SerializeField] private float movingSpeed;

    private void Awake()
    {
        firstLocation = transform.position;
    }
    private IEnumerator Bekle()
    {
        time = time + 3;

        yield return new WaitForSeconds(5);

        transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        transform.rotation = Quaternion.Euler(0, 180, 0);
        didHit = false;
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject && didHit == false)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
            transform.rotation = Quaternion.Euler(-90, 180, 0);
            score += 3;
        }

        if (!didHit)
        {
            StartCoroutine(Bekle());
            didHit = true;
        }
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        if (isMovingLeft)
        {
            // Move left
            if (transform.position.x >= firstLocation.x - 2 && didHit == false)
            {
                transform.position -= Vector3.right * movingSpeed * Time.deltaTime;
            }
            else
            {
                isMovingLeft = false;
            }
        }
        else
        {
            // Move right
            if (transform.position.x <= firstLocation.x + 2 && didHit == false)
            {
                transform.position += Vector3.right * movingSpeed * Time.deltaTime;
            }
            else
            {
                isMovingLeft = true;
            }
        }


    }
}

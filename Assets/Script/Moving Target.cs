using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class Targett : MonoBehaviour
{

    private bool didHit = false, isMovingLeft = true;

    public static int score = 0;

    public static int time = 0;

    private Vector3 firstLocation;

    [SerializeField] private float movingSpeed;

    public AudioClip clip;

    private AudioSource source;

    private void Awake()
    {
        source = GetComponent<AudioSource>();
        firstLocation = transform.position;

        source.clip = clip;
    }
    private IEnumerator Bekle()
    {
        FindAnyObjectByType<GameManagerTG>().time += 2;

        yield return new WaitForSeconds(5);

        transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        transform.rotation = Quaternion.Euler(0, 180, 0);
        didHit = false;
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject && didHit == false)
        {
            source.PlayOneShot(clip);
            transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
            transform.rotation = Quaternion.Euler(-90, 180, 0);
            FindAnyObjectByType<GameManagerTG>().score += 5;
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

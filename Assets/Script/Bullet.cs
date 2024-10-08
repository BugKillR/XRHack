using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float bulletSpeed;

    public AudioClip clip;

    private AudioSource source;

    private void Awake()
    {
        source = GetComponent<AudioSource>();

        source.clip = clip;
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        transform.Translate(0, bulletSpeed * Time.deltaTime, 0);
    }

    private void OnCollisionEnter(Collision other)
    {


        if (other.gameObject.CompareTag("obj1"))
        {
            FindAnyObjectByType<GameManager>().score ++;
            Destroy(other.gameObject);
            source.PlayOneShot(clip);
            Destroy(gameObject, clip.length);
        }
        else if (other.gameObject.CompareTag("obj2"))
        {
            FindAnyObjectByType<GameManager>().score += 2;
            Destroy(other.gameObject);
            source.PlayOneShot(clip);
            Destroy(gameObject, clip.length);
        }
        else if (other.gameObject.CompareTag("obj3"))
        {
            FindAnyObjectByType<GameManager>().score += 3;
            Destroy(other.gameObject);
            source.PlayOneShot(clip);
            Destroy(gameObject, clip.length);
        }
        Destroy(gameObject,5);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("obj1"))
        {
            FindAnyObjectByType<GameManager>().score ++;
            Destroy(other.gameObject);
            source.PlayOneShot(clip);
            Destroy(gameObject, clip.length);
        }
        else if (other.gameObject.CompareTag("obj2"))
        {
            FindAnyObjectByType<GameManager>().score += 2;
            Destroy(other.gameObject);
            source.PlayOneShot(clip);
            Destroy(gameObject, clip.length);
        }
        else if (other.gameObject.CompareTag("obj3"))
        {
            FindAnyObjectByType<GameManager>().score += 3;
            Destroy(other.gameObject);
            source.PlayOneShot(clip);
            Destroy(gameObject, clip.length);
        }
        Destroy(gameObject,5);
    }
}

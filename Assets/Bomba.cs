using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomba : MonoBehaviour
{
    private Rigidbody rb;
    public float speed;

    public AudioClip clip;

    private AudioSource source;

    void Start()
    {
        source = GetComponent<AudioSource>();
        rb = GetComponent<Rigidbody>();
        rb.AddForce(-Vector3.forward *speed, ForceMode.Impulse);

        source.clip = clip;
    }

    void OnCollisionEnter(Collision other)
    {
        
    }
    void OnTriggerEnter(Collider other)
    {
        print(other.gameObject);
        if (other.gameObject.CompareTag("Player"))
        {
            source.PlayOneShot(clip);

            StartCoroutine(Wait());
        }
        else{
            Destroy(gameObject,5);
        }
    }

    private IEnumerator Wait()
    {
        yield return new WaitForSeconds(clip.length + 0.1f);

        FindAnyObjectByType<GameManager>().health -= 5;
        Destroy(gameObject);
    }
}

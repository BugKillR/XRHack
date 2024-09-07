using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomba : MonoBehaviour
{
    private Rigidbody rb;
    public float speed;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.AddForce(-Vector3.forward *speed, ForceMode.Impulse);
    }

    void OnCollisionEnter(Collision other)
    {
        
    }
    void OnTriggerEnter(Collider other)
    {
        print(other.gameObject);
        if (other.gameObject.CompareTag("Player"))
        {
            FindAnyObjectByType<GameManager>().health -= 5;
            Destroy(gameObject);
        }
        else{
            Destroy(gameObject,5);
        }
    }
}

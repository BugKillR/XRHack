using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float speed;
    public GameObject target;

    Vector3 targetVec;

    void Start()
    {
        target = GameObject.FindWithTag("Player");
    }

    void Update()
    {
        targetVec = new Vector3(target.transform.position.x, transform.position.y, target.transform.position.z);
        transform.position = Vector3.MoveTowards(transform.position, targetVec, speed);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            FindAnyObjectByType<GameManager>().health -= 10;
            Destroy(gameObject);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    private bool didHit = false;

    public static int score = 0;

    public static int time = 0;

    private IEnumerator Bekle()
    {
        FindAnyObjectByType<GameManagerTG>().time += 1;

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
            FindAnyObjectByType<GameManagerTG>().score += 3;
        }

        if (!didHit)
        {
            StartCoroutine(Bekle());
            didHit = true;
        }
    }
}

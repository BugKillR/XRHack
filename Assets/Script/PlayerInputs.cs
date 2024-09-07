using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
//using static OVRInput;


public class PlayerInputs : MonoBehaviour
{
    [SerializeField] private float fireCD;
    public bool inTrigger;

    private bool canFire = true;

    public GameObject bullet, bulletSpawn; // kaç tane olcak? şimdilik tek mermi, mermiler rastgele olacaksa array yap belirli ama birden fazla mermi olacaksa düz obje olarak eklersin

    private Animator anim;


    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        Fire();
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Hand"))
        {
            inTrigger = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("Hand"))
        {
            inTrigger = false;
        }
    }

    public void FireAim()
    {
        if (canFire && inTrigger)
        {
        Quaternion currentRotation = bulletSpawn.transform.rotation;

            Quaternion bulletRotation = Quaternion.Euler(currentRotation.eulerAngles.x, currentRotation.eulerAngles.y, currentRotation.eulerAngles.z - 90);

            Instantiate(bullet, bulletSpawn.transform.position, bulletRotation);

            anim.SetTrigger("Fire");

            Debug.Log("Fire"); // Instanciate

            canFire = false;

            StartCoroutine(FireCooldown());
        }
    }

    void Fire()
    {

        /*OVRInput.Get(OVRInput.RawAxis1D.RIndexTrigger*/

        if (Input.GetButton("Fire1") && canFire == true)
        {
            Quaternion currentRotation = bulletSpawn.transform.rotation;

            Quaternion bulletRotation = Quaternion.Euler(currentRotation.eulerAngles.x, currentRotation.eulerAngles.y, currentRotation.eulerAngles.z - 90);

            Instantiate(bullet, bulletSpawn.transform.position, bulletRotation);

            anim.SetTrigger("Fire");

            Debug.Log("Fire"); // Instanciate

            canFire = false;

            StartCoroutine(FireCooldown());
        }
    }

    private IEnumerator FireCooldown()
    {
        yield return new WaitForSeconds(fireCD); // 30 saniye fire1 klibi

        canFire = true;
    }
}


﻿using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
//using static OVRInput;


public class PlayerInputs : MonoBehaviour
{
    [SerializeField] private float fireCD;

    private bool canFire = true;

    public GameObject bullet, bulletSpawn; // kaç tane olcak? şimdilik tek mermi, mermiler rastgele olacaksa array yap belirli ama birden fazla mermi olacaksa düz obje olarak eklersin

    private Animator anim;

    public AudioClip gunShot;

    private AudioSource audio;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        audio = GetComponent<AudioSource>();
        XRGrabInteractable grabbable = GetComponent<XRGrabInteractable>();
        grabbable.activated.AddListener(FireAim);
    }

    private void Update()
    {
        Fire();
    }

    public void FireAim(ActivateEventArgs arg)
    {
        if (canFire)
        {
        Quaternion currentRotation = bulletSpawn.transform.rotation;

            Quaternion bulletRotation = Quaternion.Euler(currentRotation.eulerAngles.x, currentRotation.eulerAngles.y, currentRotation.eulerAngles.z - 90);

            Instantiate(bullet, bulletSpawn.transform.position, bulletRotation);

            anim.SetTrigger("Fire");

            audio.clip = gunShot;

            audio.PlayOneShot(gunShot);

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

        audio.Stop();

        canFire = true;
    }
}


/*
 * Author: Wee Kiat
 * Date: 7/2/2023
 * Description: Gun script
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PGun : MonoBehaviour
{
    /// <summary>
    /// Gun damage
    /// </summary>
    public float damage = 10f;

    /// <summary>
    /// Gun range
    /// </summary>
    public float range = 20f;

    /// <summary>
    /// Camera
    /// </summary>
    public Camera fpsCam;

    /// <summary>
    /// Access particlesystem
    /// </summary>
    public ParticleSystem muzzleFlash;

    /// <summary>
    /// Access vfx with gameobject
    /// </summary>
    public GameObject impactEffect;

    /// <summary>
    /// Retrieve shooting audio
    /// </summary>
    public AudioSource shootingAudio;

    /// <summary>
    /// Run the code on every update
    /// </summary>
    void Update()
    {
        if (Input.GetButtonDown("Fire1")) // If fire1 is triggered
        {
            shootingAudio.Play();  // play shooting sound
            Shoot(); // run shoot function
        }
    }

    /// <summary>
    /// Open fire with the gun
    /// </summary>
    void Shoot()
    {
        muzzleFlash.Play(); // play muzzleflash

        RaycastHit hit;
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
        {
            //Debug.Log(hit.transform.name);

            Enemy enemy = hit.transform.GetComponent<Enemy>(); // If hit Enemy
            if (enemy != null) // Enemy is around
            {
                enemy.TakeDamage(damage); // reduce enemy health
            }

            Instantiate(impactEffect, hit.point, Quaternion.LookRotation(hit.normal));
        }
    }

}
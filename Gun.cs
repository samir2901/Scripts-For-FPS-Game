using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public float damage = 10f;
    public float range = 100f;
    public float fireRate = 15f;

    public Camera fpsCamera;
    public ParticleSystem muzzleFlash;
    public float impactForce = 70f;
    public GameObject impactEffect;
    public AudioSource firingSound;

    private float nextTimeToFire = 0f;
    
   
    void Update()
    {
        if (Input.GetButtonDown("Fire1") && Time.time >= nextTimeToFire)
        {
            //Debug.Log("Yo! I am firing..");
            nextTimeToFire = Time.time + (1f / fireRate);
            Shoot();
            firingSound.Play();
        }
        
    }

    void Shoot()
    {
        RaycastHit hitInfo;
        bool ray = Physics.Raycast(fpsCamera.transform.position, fpsCamera.transform.forward, out hitInfo, range);
        if (ray)
        {
            muzzleFlash.Play();
            Target target = hitInfo.transform.GetComponent<Target>();
            if (target != null)
            {
                //Debug.Log(hitInfo.transform.name);
                if (target.CompareTag("Enemy")) 
                {
                    target.TakeDamage(damage);
                }
                
            }
            if(hitInfo.rigidbody != null)
            {
                hitInfo.rigidbody.AddForce(-hitInfo.normal * impactForce);
            }

            GameObject impactGO = Instantiate(impactEffect, hitInfo.point, Quaternion.LookRotation(hitInfo.normal));
            Destroy(impactGO, 2f);
        }

    }
}

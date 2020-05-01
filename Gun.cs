using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public float damage = 10f;
    public float range = 100f;
    public float fireRate = 15f;

    public int maxAmmo = 100;
    public int currentAmmo = -1;
    public float reloadTime = 1f;
    private bool isReloading = false;

    public Camera fpsCamera;
    public ParticleSystem muzzleFlash;
    public float impactForce = 70f;
    public GameObject impactEffect;

    public AudioClip reloadSound;
    public AudioClip shootSound;
    public AudioSource gunSound;
    public Animator gunAnim;


    private float nextTimeToFire = 0f;

    private void Start()
    {
        if (currentAmmo == -1)
        {
            currentAmmo = maxAmmo;
        }
    }

    void Update()
    {
        //Debug.Log(currentAmmo);
        if (isReloading) 
        {
            return;
        }
        if (currentAmmo <= 0)
        {
            StartCoroutine(Reload());
            isReloading = false;
            return;
        }
        if (Input.GetButtonDown("Fire1") && Time.time >= nextTimeToFire)
        {
            //Debug.Log("Yo! I am firing..");
            nextTimeToFire = Time.time + (1f / fireRate);
            Shoot();
            gunAnim.SetBool("Shooting", true);
            gunSound.PlayOneShot(shootSound);
            fpsCamera.GetComponent<MouseLook>().AddRecoil(2, 2);
        }
        else
        {
            gunAnim.SetBool("Shooting", false);
            gunAnim.SetBool("Reloading", false);
        }        
    }

    IEnumerator Reload()
    {
        isReloading = true;
        //Debug.Log("Reloading.....");        
        gunAnim.SetBool("Reloading", true);
        gunAnim.SetBool("Shooting", false);
        gunSound.PlayOneShot(reloadSound,0.3f);
        yield return new WaitForSeconds(reloadTime);        
        gunAnim.SetBool("Reloading", false);
        currentAmmo = maxAmmo;
    }

    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log(other);
        if (other.CompareTag("Ammo"))
        {
            if (currentAmmo < maxAmmo)
            {
                gunSound.PlayOneShot(reloadSound, 0.3f);
                currentAmmo = maxAmmo;
                isReloading = false;
                Destroy(other.gameObject);
            }            
        }
    }
    void Shoot()
    {
        currentAmmo--;        
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

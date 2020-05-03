using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoSpawnManager : MonoBehaviour
{
    [SerializeField] int ammoSpawnNumber;
    public GameObject ammo;
    private int ammoCount;
    //Vector3 spawnPos;
    // Start is called before the first frame update
    void Start()
    {
        SpawnAmmo();
    }

    // Update is called once per frame
    void Update()
    {
        ammoCount = GameObject.FindGameObjectsWithTag("Ammo").Length;        
        if(ammoCount <= ammoSpawnNumber)
        {
            SpawnAmmo();
        }
    }

    void SpawnAmmo()
    {
        Vector3 pos = new Vector3(Random.Range(0f, 360f), 1.3644f, Random.Range(100f, 360f));
        //Debug.Log(pos);
        Instantiate(ammo, pos, ammo.transform.rotation);
    }

    
    
}

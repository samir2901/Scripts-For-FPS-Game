using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoSpawnManager : MonoBehaviour
{
    [SerializeField] int ammoSpawnNumber = 1;
    [SerializeField] float minX = 0f, maxX = 360f;
    [SerializeField] float minZ = 100f, maxZ = 360f;
    [SerializeField] float yPos = 1.3644f;
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
        Vector3 pos = new Vector3(Random.Range(minX, maxX), yPos, Random.Range(minZ, maxZ));
        //Debug.Log(pos);
        Instantiate(ammo, pos, ammo.transform.rotation);
    }

    
    
}

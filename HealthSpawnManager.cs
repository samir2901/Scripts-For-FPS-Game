using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSpawnManager : MonoBehaviour
{
    [SerializeField] int healthSpawnNumber = 1;
    [SerializeField] float minX = 0f, maxX = 360f;
    [SerializeField] float minZ = 100f, maxZ = 360f;
    [SerializeField] float yPos = 1.3644f;
    public GameObject healthPrefab;
    private int healthObjCount;
    // Start is called before the first frame update
    void Start()
    {
        SpawnHealth();
    }

    // Update is called once per frame
    void Update()
    {
        healthObjCount = GameObject.FindGameObjectsWithTag("Health").Length;
        if(healthObjCount <= healthSpawnNumber)
        {
            SpawnHealth();
        }
    }

    void SpawnHealth()
    {
        Vector3 pos = new Vector3(Random.Range(minX, maxX), yPos, Random.Range(minZ, maxZ));
        //Debug.Log(pos);
        Instantiate(healthPrefab, pos, healthPrefab.transform.rotation);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSpawnManager : MonoBehaviour
{
    [SerializeField] int healthSpawnNumber;
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
        Vector3 pos = new Vector3(Random.Range(0f, 360f), 1.3644f, Random.Range(100f, 360f));
        //Debug.Log(pos);
        Instantiate(healthPrefab, pos, healthPrefab.transform.rotation);
    }
}

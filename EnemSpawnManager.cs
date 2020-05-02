using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemSpawnManager : MonoBehaviour
{
    public GameObject enemyPrefab;
    private int enemyCount;
    // Start is called before the first frame update
    void Start()
    {
        SpawnEnemy();
    }

    // Update is called once per frame
    void Update()
    {
        enemyCount = GameObject.FindGameObjectsWithTag("Enemy").Length;
        //Debug.Log(enemyCount);
        if(enemyCount <= 10)
        {
            SpawnEnemy();
        }
    }

    void SpawnEnemy()
    {
        Vector3 pos = new Vector3(Random.Range(0f, 360f), 1.3644f, Random.Range(100f, 360f));        
        Instantiate(enemyPrefab, pos, enemyPrefab.transform.rotation);
    }
}

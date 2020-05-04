using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemSpawnManager : MonoBehaviour
{
    [SerializeField] int EnemySpawnNumber = 10;
    [SerializeField] float minX = 0f, maxX = 360f;
    [SerializeField] float minZ = 100f, maxZ = 360f;
    [SerializeField] float yPos = 1.3644f;
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
        if(enemyCount <= EnemySpawnNumber)
        {
            SpawnEnemy();
        }
    }

    void SpawnEnemy()
    {
        Vector3 pos = new Vector3(Random.Range(minX, maxX), yPos, Random.Range(minZ, maxZ));        
        Instantiate(enemyPrefab, pos, enemyPrefab.transform.rotation);
    }
}

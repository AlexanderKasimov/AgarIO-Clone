using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public EnemyController enemyPrefab;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnEnemy", 0f, 30f);
    }

    private void SpawnEnemy()
    {
        float mapBoxSize = GameManager.instance.mapBoxSize;
        Vector2 spawnPosition = new Vector2(Random.Range(-mapBoxSize, mapBoxSize), Random.Range(-mapBoxSize, mapBoxSize));
        Collider2D collider = Physics2D.OverlapBox(spawnPosition, Vector2.one * 2f, 0f);
        if (!collider)
        {
            Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
            Debug.Log("EnemySpawned");
        }
        else
        {
            SpawnEnemy();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

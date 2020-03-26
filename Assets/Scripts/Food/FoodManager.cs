using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodManager : MonoBehaviour
{
    public GameObject[] foodPrefabs;

    public float foodSpawnBoxSize = 30f;


    //private IEnumerator SpawnFood()

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnFood", 0f, 30f);
    }

    public void SpawnFood()
    {
        for (int i = 0; i < 50; i++)
        {
            Vector2 spawnPosition = new Vector2(Random.Range(-foodSpawnBoxSize, foodSpawnBoxSize), Random.Range(-foodSpawnBoxSize, foodSpawnBoxSize));
            Collider2D collider = Physics2D.OverlapBox(spawnPosition, Vector2.one * 2f, 0f);
            if (!collider)
            {
                Instantiate(foodPrefabs[Random.Range(0, foodPrefabs.Length)], spawnPosition, Quaternion.identity);
            }  
           
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

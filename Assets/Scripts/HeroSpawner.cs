using System.Collections;
using UnityEngine;

// This is a Hero spawner script, it behaves like the mob spawner in Minecraft - Gatsby

public class HeroSpawner : MonoBehaviour
{
    public GameObject heroPrefab;                // Enemy prefab to spawn


    public int minHerosPerBatch = 3;            // Minimum number of heros per batch
    public int maxHerosPerBatch = 6;            // Maximum number of heros per batch


    public float minSpawnInterval = 3f;           // Minimum interval between spawns
    public float maxSpawnInterval = 5f;           // Maximum interval between spawns

    public float spawnBatchRadius = 2f;           // Radius within which heros will be spawned in each batch

    public void Start()
    {
        StartCoroutine(SpawnHeros());
    }
    private IEnumerator SpawnHeros()
    {
        float interval = Random.Range(minSpawnInterval, maxSpawnInterval);
        yield return new WaitForSeconds(interval);

        int herosToSpawn = Random.Range(minHerosPerBatch, maxHerosPerBatch);

        for (int i = 0; i < herosToSpawn; i++)
        {
            Vector2 spawnOffset = Random.insideUnitCircle * spawnBatchRadius;
            Vector2 spawnPosition = (Vector2)gameObject.transform.position + spawnOffset;

            Instantiate(heroPrefab, spawnPosition, Quaternion.identity);
        }
    }
}



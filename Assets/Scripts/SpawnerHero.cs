using UnityEngine;
using System.Collections;

public class SpawnerHero : MonoBehaviour
{
    public GameObject cubePrefab;
    public float spawnInterval = 1f;
    public int unitsToSpawn = 5;
    public float spawnHeightOffset = 1f;

    void Start()
    {
        StartCoroutine(SpawnUnits());
    }

    IEnumerator SpawnUnits()
    {
        for (int i = 0; i < unitsToSpawn; i++)
        {
            Vector3 spawnPos = transform.position + Vector3.up * spawnHeightOffset;
            Instantiate(cubePrefab, spawnPos, Quaternion.identity);

            // Optional: fix Rigidbody collision
            var rb = cubePrefab.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.collisionDetectionMode = CollisionDetectionMode.ContinuousDynamic;
                rb.WakeUp();
            }
        }

        yield break; // All units spawned immediately
    }
}

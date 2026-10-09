using System.Collections.Generic;
using UnityEngine;

public class SpecialBombSpawner : MonoBehaviour
{
    // The bomb which is spawned into the scene
    public GameObject[] specialBombPrefab;

    // All of the possible places where a bomb COULD be spawned on
    public Transform[] spawnPoints; 

    // Stores how long it waits before trying to spawn another bomb
    public float spawnInterval;

    public float spawnDelay;

    // How big of an area around each spawn point, if something is already in this radius it will NOT spawn one there
    public float spawnCheckRadius = 0.1f; 

    void Start()
    {
        // Pick a random amount of time between 4 and 8 seconds
        spawnInterval = Random.Range(4f, 8f);

        // Pick a random amount of time between 4 and 8 seconds to wait before spawning the first bomb
        spawnDelay = Random.Range(4f, 8f);

        SpawnSpecialBomb();
    }

    void Update()
    {
        // Decrease the spawn delay by the amount of time that has passed since the last frame
        spawnDelay -= Time.deltaTime;

        // Make sure the spawn delay does not go below 0
        if (spawnDelay <= 0)
        {
            spawnDelay = 0;
        }
    }

    void SpawnSpecialBomb()
    {
        // Make a empty list
        // This list will hold all of the spawn points that are safe to use
        List<int> availableSpawnPoints = new List<int>();

        // Go through every spawn point one at a time
        for (int i = 0; i < spawnPoints.Length; i++)
        {
            // Check if their is NOT already a bomb at this spawn point
            if (!BombAtSpawnPoint(spawnPoints[i]))
            {
                // If there isnt a bomb there than add this spawn point to the list of usable spawn points
                availableSpawnPoints.Add(i);
            }
        }

        // Check if we found at least one empty spawn point
        if (availableSpawnPoints.Count > 0)
        {
            // Pick a random number from the list of available spawn points
            int randomListIndex = Random.Range(0, availableSpawnPoints.Count);

            // Get the actual spawn point number from the list
            int spawnIndex = availableSpawnPoints[randomListIndex];

            // Now get the transform of the spawn point we picked 
            Transform spawnPoint = spawnPoints[spawnIndex];

            // Check if the spawn delay has reached 0
            if (spawnDelay <= 0)
            {
                // Create the bomb at the selected spawn point
                Instantiate(specialBombPrefab[Random.Range(0, specialBombPrefab.Length)], spawnPoint.position, spawnPoint.rotation);
            }
        }

        // Pick another random delay for the next bomb
        spawnInterval = Random.Range(4f, 8f);

        // Wait for the amount of time stored in spawnInterval (4 - 8)
        Invoke(nameof(SpawnSpecialBomb), spawnInterval);
    }

    bool BombAtSpawnPoint(Transform spawnPoint)
    {
        // Check a circle around this spawn (0.1)
        Collider2D[] colliders = Physics2D.OverlapCircleAll(spawnPoint.position, spawnCheckRadius);

        // Look through every collider found
        foreach (Collider2D collider in colliders)
        {
            // Check if the collider belongs to something that has the BombTimer script on it (The best way i could find to doing this)
            if (collider.GetComponentInParent<BombTimer>())
            {
                // If we found a bomb then return true
                return true;
            }
        }

        // If unity did not find a bomb then return false (Fail safe)
        return false;
    }
}
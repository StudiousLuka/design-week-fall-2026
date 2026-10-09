using UnityEngine;

public class BombSpawner : MonoBehaviour
{
    public GameObject bombPrefab; // Reference to the Bomb prefab

    public Transform[] spawnPoints; // Array of spawn points for the bomb

    public float spawnInterval; // Interval between bomb spawns in seconds

    private int lastSpawnIndex = -1; // Keep track of the last spawn point index to avoid spawning at the same point consecutively

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        spawnInterval = Random.Range(0.25f, 0.5f); // Set a random spawn interval between 0.25 and 0.5 seconds
        SpawnBomb(); // Call the method to spawn the bomb at the start of the game
    }
    void SpawnBomb()
    {
        while (true)
        {
            int randomIndex = Random.Range(0, spawnPoints.Length); // Get a random index for the spawn points array
            if (randomIndex != lastSpawnIndex) // Check if the random index is different from the last spawn index
            {
                lastSpawnIndex = randomIndex; // Update the last spawn index
                Transform spawnPoint = spawnPoints[randomIndex]; // Get the spawn point at the random index
                Instantiate(bombPrefab, spawnPoint.position, spawnPoint.rotation); // Instantiate the bomb at the selected spawn point
                break; // Exit the loop after successfully spawning a bomb at a different point
            }
        }

        spawnInterval = Random.Range(0.25f, 0.5f); // Set a new random spawn interval for the next bomb
        Invoke("SpawnBomb", spawnInterval); // Schedule the next bomb spawn after the specified interval
    }
}
using UnityEngine;

public class BombSpawner : MonoBehaviour
{
    public GameObject bombPrefab; // Reference to the Bomb prefab

    public Transform[] spawnPoints; // Array of spawn points for the bomb

    public float spawnInterval; // Interval between bomb spawns in seconds

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        spawnInterval = Random.Range(1, 4); // Set a random spawn interval between 1 and 4 seconds
        SpawnBomb(); // Call the method to spawn the bomb at the start of the game
    }
    void SpawnBomb()
    {
        int randomIndex = Random.Range(0, spawnPoints.Length); // Get a random index for the spawn points array
        Transform spawnPoint = spawnPoints[randomIndex]; // Get the spawn point at the random index
        Instantiate(bombPrefab, spawnPoint.position, spawnPoint.rotation); // Instantiate the bomb at the selected spawn point

        Invoke("SpawnBomb", spawnInterval); // Schedule the next bomb spawn after the specified interval
        spawnInterval = Random.Range(1, 4); // Set a new random spawn interval for the next bomb
    }
}
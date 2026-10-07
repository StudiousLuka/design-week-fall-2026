using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public float gameTime = 60f; // Total game time in seconds

    public TMP_Text timeRemaining; // Reference to the TextMeshPro text component to display time remaining

    public float bombTime = 5f; // Total bomb time in seconds

    public TMP_Text bombTimeText; // Reference to the TextMeshPro text component to display bomb time

    public bool safeZone; // Variable to check if Bomb is in a safe zone

    public GameObject bomb; // Reference to the Bomb GameObject

    public Transform[] spawnPoints; // Array of spawn points for the bomb

    public float spawnInterval; // Interval between bomb spawns in seconds

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        safeZone = false;
        spawnInterval = Random.Range(1,9); // Set a random spawn interval between 1 and 9 seconds
        SpawnBomb(); // Call the method to spawn the bomb at the start of the game
    }

    // Update is called once per frame
    void Update()
    {
        gameTime -= Time.deltaTime; // Decrease game time by the time elapsed since the last frame
        if (gameTime <= 0)
        {
            gameTime = 0; // Ensure game time doesn't go below zero
            Debug.Log("Game Over!"); // Log game over message
        }
        else
        {
            UpdateTimer(); // Update the timer display
        }

        bombTime -= Time.deltaTime; // Decrease bomb time by the time elapsed since the last frame
        if (bombTime <= 0)
        {
            bombTime = 0; // Ensure bomb time doesn't go below zero
            CheckSafeZone(); // Call the method to check if the bomb is in a safe zone
            Destroy(bomb.gameObject); // Destroy the bomb GameObject
        }
        else
        {
            UpdateBombTimer(); // Update the bomb timer display
        }
    }
    void UpdateTimer()
    {
        int minutes = Mathf.FloorToInt(gameTime / 60); // Calculate minutes
        int seconds = Mathf.FloorToInt(gameTime % 60); // Calculate seconds
        timeRemaining.text = "Time Remaining: " + string.Format("{0:0}:{1:00}", minutes, seconds); // Update time remaining
    }
    void UpdateBombTimer()
    {
        int seconds = Mathf.FloorToInt(bombTime); // Calculate seconds
        bombTimeText.text = "" + seconds; // Update bomb time display
    }
    void CheckSafeZone()
    {
        if (bomb.transform.position.x <= -7 && bomb.transform.position.x >= -9 && bomb.transform.position.y <= -3 && bomb.transform.position.z >= -5)
        {
            safeZone = true; // Bomb is in a safe zone
            Debug.Log("Bomb is in a safe zone!"); // Log message indicating bomb is in a safe zone
        }
        else
        {
            safeZone = false; // Bomb is not in a safe zone
            gameTime -= 1; // Decrease game time by 10 seconds as a penalty for the bomb exploding
            Debug.Log("Bomb is not in a safe zone! Bomb has exploded!"); // Log message indicating bomb is not in a safe zone
        }
    }
    void SpawnBomb()
    {
        int randomIndex = Random.Range(0, spawnPoints.Length); // Get a random index for the spawn points array
        Transform spawnPoint = spawnPoints[randomIndex]; // Get the spawn point at the random index
        Instantiate(bomb, spawnPoint.position, spawnPoint.rotation); // Instantiate the bomb at the selected spawn point

        Invoke("SpawnBomb", spawnInterval); // Schedule the next bomb spawn after the specified interval
    }    
}
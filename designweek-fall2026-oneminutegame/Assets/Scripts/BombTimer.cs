using UnityEngine;
using TMPro;

public class BombTimer : MonoBehaviour
{
    public float bombTime = 5f; // Total bomb time in seconds

    public TMP_Text bombTimeText; // Reference to the TextMeshPro text component to display bomb time

    public bool safeZone; // Variable to check if Bomb is in a safe zone

    public GameObject bomb; // Reference to the Bomb GameObject

    public GameTimer gameTime; // Reference to the GameTimer script

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        safeZone = false;
        gameTime = FindAnyObjectByType<GameTimer>(); // Get the GameTimer component from the scene
    }

    // Update is called once per frame
    void Update()
    {
        bombTime -= Time.deltaTime; // Decrease bomb time by the time elapsed since the last frame
        if (bombTime <= 0)
        {
            bombTime = 0; // Ensure bomb time doesn't go below zero
            CheckSafeZone(); // Call the method to check if the bomb is in a safe zone
            Destroy(bomb); // Destroy the bomb GameObject
        }
        else
        {
            UpdateBombTimer(); // Update the bomb timer display
        }
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
            gameTime.gameTime -= 1f; // Decrease game time by 10 seconds if bomb is not in a safe zone
            Debug.Log("Bomb is not in a safe zone! Bomb has exploded!"); // Log message indicating bomb is not in a safe zone
        }
    }
}
using UnityEngine;
using UnityEngine.Experimental.Playables;
using TMPro;

public class GameTimer : MonoBehaviour
{
    public float gameTime = 60f; // Total game time in seconds

    public TMP_Text timeRemaining; // Reference to the TextMeshPro text component to display time remaining

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
    }
    void UpdateTimer()
    {
        int minutes = Mathf.FloorToInt(gameTime / 60); // Calculate minutes
        int seconds = Mathf.FloorToInt(gameTime % 60); // Calculate seconds
        timeRemaining.text = string.Format("{0:0}:{1:00}", minutes, seconds); // Update time remaining
    }
}
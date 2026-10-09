using TMPro;
using UnityEngine;

public class HighscoreKeeper : MonoBehaviour
{
    public Scorekeeper points; // Reference to the Scorekeeper script to update score

    public TMP_Text highscoreDisplay; // Reference to the TextMeshPro text component to display high score

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ShowHighScore(); // Display the high score on the screen
    }
    void ShowHighScore()
    {
        highscoreDisplay.text = "Highscore: " + Scorekeeper.highScore; // Update high score display with the current high score
    }
}
using UnityEngine;
using TMPro;

public class ScoreTracker : MonoBehaviour
{
    public Scorekeeper points; // Reference to the Scorekeeper script to update score

    public TMP_Text scoreDisplay; // Reference to the TextMeshPro text component to display score

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ShowScore(); // Call the method to display the score at the start of the game
    }

    void ShowScore()
    {
        scoreDisplay.text = "Score: " + Scorekeeper.score; // Update score display with the current score from Scorekeeper
    }
}
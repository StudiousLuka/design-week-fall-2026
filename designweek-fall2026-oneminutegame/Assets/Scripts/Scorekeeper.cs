using UnityEngine;
using TMPro;
using Unity.VisualScripting;

public class Scorekeeper : MonoBehaviour
{
    public static int score;

    public TMP_Text scoreKeeper; // Reference to the TextMeshPro text component to display score

    void Start()
    {
        score = 0; // Initialize score to zero at the start of the game
    }
    // Update is called once per frame
    void Update()
    {
        UpdateScore(); // Update the score display
    }
    void UpdateScore()
    { 
        scoreKeeper.text = "Score: " + score; // Update score display with the current score
    }
}
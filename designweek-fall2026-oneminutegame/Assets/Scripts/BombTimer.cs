using UnityEngine;
using TMPro;

public class BombTimer : MonoBehaviour
{
    public float bombTime = 5f; // Total bomb time in seconds

    public TMP_Text bombTimeText; // Reference to the TextMeshPro text component to display bomb time

    // Update is called once per frame
    void Update()
    {
        bombTime -= Time.deltaTime; // Decrease bomb time by the time elapsed since the last frame
        if (bombTime <= 0)
        {
            bombTime = 0; // Ensure bomb time doesn't go below zero
            Debug.Log("Bomb exploded!"); // Log bomb explosion message
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
}
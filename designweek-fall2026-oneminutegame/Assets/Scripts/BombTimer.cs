using UnityEngine;
using TMPro;

public class BombTimer : MonoBehaviour
{
    public float bombTime = 5f; // Total bomb time in seconds

    public TMP_Text bombTimeText; // Reference to the TextMeshPro text component to display bomb time

    public bool safeZone; // Variable to check if Bomb is in a safe zone

    public GameObject bomb; // Reference to the Bomb GameObject

    public GameObject explosionSprite; // Reference to the explosion sprite GameObject

    public GameTimer gameTime; // Reference to the GameTimer script

    public AudioClip bombExplosion; // Reference to the AudioClip for bomb explosion sound

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

            AudioSource.PlayClipAtPoint(bombExplosion, bomb.transform.position, 2.0f); // Play the bomb explosion sound at the bomb's position)
            Instantiate(explosionSprite, bomb.transform.position, Quaternion.identity); // Instantiate the explosion sprite at the bomb's position)
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

        // If bombTimeText is not null then update the bomb time display
        // This fixes the warning spam
        if (bombTimeText != null)
        {
            bombTimeText.text = "" + seconds; // Update bomb time display
        }
   
    }
    void CheckSafeZone()
    {
        if (bomb.transform.position.x <= -6 && bomb.transform.position.x >= -5 && bomb.transform.position.y <= -1 && bomb.transform.position.z >= -3)
        {
            safeZone = true; // Bomb is in a safe zone
        }
        else
        {
            safeZone = false; // Bomb is not in a safe zone
            gameTime.gameTime -= 1f; // Decrease game time by 1 second if bomb is not in a safe zone
        }
    }
}
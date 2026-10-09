using System.Collections;
using UnityEngine;
using TMPro;

public class DragExtraTimeBomb : MonoBehaviour
{
    [SerializeField] private GameObject bomb;

    public Scorekeeper scorePoints; // Reference to the Scorekeeper script to update score

    public AudioClip bombSecured; // Reference to the AudioClip for bomb secured sound

    public GameTimer gameTime; // Reference to the GameTimer script to add extra time

    void Start()
    {
        gameTime = FindAnyObjectByType<GameTimer>(); // Find the GameTimer script in the scene
    }

    private void OnMouseDrag()
    {
        // This triggers it every frame while the mouse click is held down over the object collider
        Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        // Keeps the object's original Z depth as the game is 2D and will not cause any 
        transform.position = new Vector3(mouseWorldPos.x, mouseWorldPos.y, transform.position.z);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("BombGarbage"))
        {
            Scorekeeper.score += 1; // Increase score by 1 when the bomb is dragged into the garbage can
            gameTime.gameTime += 1f; // Add 1 seconds to the game timer when the bomb is secured

            AudioSource.PlayClipAtPoint(bombSecured, bomb.transform.position, 1.0f); // Play the bomb secured sound at the bomb's position)
            Destroy(bomb);
            
        }
    }
}
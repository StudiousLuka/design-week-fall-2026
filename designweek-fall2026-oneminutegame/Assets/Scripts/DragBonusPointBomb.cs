using System.Collections;
using UnityEngine;
using TMPro;

public class DragBonusPointBomb : MonoBehaviour
{
    [SerializeField] private GameObject bomb;

    public Scorekeeper scorePoints; // Reference to the Scorekeeper script to update score

    public AudioClip bombSecured; // Reference to the AudioClip for bomb secured sound

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
            Scorekeeper.score += 2; // Increase score by 2 when the bomb is dragged into the garbage can

            AudioSource.PlayClipAtPoint(bombSecured, bomb.transform.position, 1.0f); // Play the bomb secured sound at the bomb's position)
            Destroy(bomb);
            
        }
    }
}
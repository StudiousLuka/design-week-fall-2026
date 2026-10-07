using UnityEngine;

public class DraggableObject : MonoBehaviour
{
    public static int score = 0;
    [SerializeField] private GameObject bomb;

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
            score++;
            Debug.Log("hit detect");
            Destroy(bomb);
            Debug.Log("Score: " + score);
        }
    }

}
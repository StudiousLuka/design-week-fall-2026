using UnityEngine;

public class BombZones : MonoBehaviour
{
    public bool safeZone; // Variable to check if Bomb is in a safe zone

    public GameObject bomb; // Reference to the Bomb GameObject

    private BombTimer checkBombTimer; // Reference to the BombTimer script

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        safeZone = false;
        checkBombTimer = bomb.GetComponent<BombTimer>(); // Get the BombTimer component from the Bomb GameObject
    }

    // Update is called once per frame
    void Update()
    {
        if (checkBombTimer.bombTime <= 0) // Check if the bomb timer has reached zero
        {
            CheckSafeZone(); // Call the method to check if the bomb is in a safe zone
        }
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
            Debug.Log("Bomb is not in a safe zone! Bomb has exploded!"); // Log message indicating bomb is not in a safe zone
        }
    }
}
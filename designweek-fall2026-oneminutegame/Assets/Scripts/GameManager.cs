using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject bombPrefab; // Reference to the Bomb prefab

    public AudioSource bombExplosion; // Reference to the AudioSource component for bomb explosion sound

    public BombTimer bombTime; // Reference to the BombTimer script

    private int bombExplosionCount = 0; // Counter to keep track of the number of bomb explosions

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        bombTime = FindAnyObjectByType<BombTimer>(); // Get the BombTimer component from the scene
    }

    // Update is called once per frame
    void Update()
    {
        CheckIfExploded(); // Check if the bomb has exploded)
        if (bombExplosionCount < 0)
        {
            bombExplosion.Play(); // Play the bomb explosion sound
            bombExplosionCount = 0; // Reset the bomb explosion counter
        }
    }
    void CheckIfExploded()
    {
        if (bombTime.bombTime <= 0 && !bombTime.safeZone)
        {
            bombExplosionCount += 1; // Increment the bomb explosion counter
        }
    }
}
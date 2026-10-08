using UnityEngine;

public class DestroySelf : MonoBehaviour
{
    public float destroyTime = 1f; // Time in seconds before the object destroys itself
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Destroy(gameObject, destroyTime);
    }
}
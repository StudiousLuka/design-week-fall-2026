using UnityEngine;

public class BackToTitle : MonoBehaviour
{
    public float delay = 1.0f; // Delay in seconds before loading the title scene

    // Update is called once per frame
    void Update()
    {
        delay -= Time.deltaTime; // Decrease the delay by the time elapsed since the last frame
        if (delay <= 0)
        {
            delay = 0; // Ensure delay doesn't go below zero

            // Check if user presses the left mouse button
            if (Input.GetMouseButtonDown(0))
            {
                LoadTitle();
            }
        }
    }
    public void LoadTitle()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex - 3);
    }
}
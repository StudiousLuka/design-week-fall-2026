using UnityEngine;

public class NextScene : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        // Check if user presses the left mouse button
        if (Input.GetMouseButtonDown(0))
        {
            LoadNextScene();
        }
    }
    public void LoadNextScene()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex + 1);
    }
}
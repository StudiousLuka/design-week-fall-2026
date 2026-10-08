using UnityEngine;

public class BackToTitle : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        // Check if user presses the left mouse button
        if (Input.GetMouseButtonDown(0))
        {
            LoadTitle();
        }
    }
    public void LoadTitle()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex - 3);
    }
}
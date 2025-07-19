using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class LevelLoader : MonoBehaviour
{
    public Animator transition;
    public float transitionTime = 1f;

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // Left mouse button
        {
            LoadNextLevel();
        }
    }

    public void LoadNextLevel()
    {
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
    }

    IEnumerator LoadLevel(int levelIndex)
    {
        // Play the transition animation
        transition.SetTrigger("Start");

        // Wait for the animation to finish
        yield return new WaitForSeconds(transitionTime);

        // Load the next scene
        SceneManager.LoadScene(levelIndex);
    }
}

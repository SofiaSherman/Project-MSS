using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class SceneLoader : MonoBehaviour
{
    [Tooltip("Scene index to load (from Build Settings)")]
    public int sceneNumber;

    [Tooltip("Delay before loading the scene")]
    public float loadDelay = 2f;

    // Called by the Button
    public void LoadScene()
    {
        StartCoroutine(LoadSceneAfterDelay());
    }

    private IEnumerator LoadSceneAfterDelay()
    {
        yield return new WaitForSeconds(loadDelay);

        SceneManager.LoadScene(sceneNumber);
    }
}
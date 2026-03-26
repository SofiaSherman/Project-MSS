using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    [Tooltip("Scene index to load (from Build Settings)")]
    public int sceneNumber;

    // This function will be called by the Button
    public void LoadScene()
    {
        SceneManager.LoadScene(sceneNumber);
    }
}
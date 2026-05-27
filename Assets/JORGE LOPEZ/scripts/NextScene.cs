using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class NextScene : MonoBehaviour
{
    [Header("Scene Settings")]
    public int nextSceneIndex;

    [Header("Timer Settings")]
    public float loadAfterSeconds = 5f;

    void Start()
    {
        StartCoroutine(LoadSceneAfterTime());
    }

    IEnumerator LoadSceneAfterTime()
    {
        yield return new WaitForSeconds(loadAfterSeconds);

        SceneManager.LoadScene(nextSceneIndex);
    }
}
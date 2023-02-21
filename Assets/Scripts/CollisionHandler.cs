using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField] private float levelLoadDelay = 1f;
    
    private void OnCollisionEnter(Collision collision)
    {
        switch (collision.gameObject.tag)
        {
            case "Friendly":
                Debug.Log("Friendly");
                break;
            case "Finish":
                StartSuccessSequence();
                break;
            case "Fuel":
                Debug.Log("Fuel");
                break;
            default:
                StartCrushSequence();
                break;
        }
    }

    private void StartCrushSequence()
    {
        GetComponent<Movement>().enabled = false;
        Invoke(nameof(ReloadLevel), levelLoadDelay);
    }
    private void StartSuccessSequence()
    {
        GetComponent<Movement>().enabled = false;
        Invoke(nameof(LoadNextLevel), levelLoadDelay);
    }

    private void ReloadLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void LoadNextLevel()
    {
        var nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
        if (nextSceneIndex == SceneManager.sceneCountInBuildSettings)
            nextSceneIndex = 0;
        SceneManager.LoadScene(nextSceneIndex);
    }
}

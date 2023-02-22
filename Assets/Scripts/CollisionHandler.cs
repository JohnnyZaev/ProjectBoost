using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField] private float levelLoadDelay = 1f;
    [SerializeField] private AudioClip successSound;
    [SerializeField] private AudioClip crushSound;

    private AudioSource _audioSource;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

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
        _audioSource.PlayOneShot(crushSound);
        GetComponent<Movement>().enabled = false;
        Invoke(nameof(ReloadLevel), levelLoadDelay);
    }
    private void StartSuccessSequence()
    {
        _audioSource.PlayOneShot(successSound);
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

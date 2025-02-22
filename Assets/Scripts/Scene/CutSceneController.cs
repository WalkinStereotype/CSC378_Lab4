using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class CutsceneController : MonoBehaviour
{
    public VideoPlayer videoPlayer;
    public string nextSceneName = "MainMenu"; // Change this to your actual menu scene

    void Start()
    {
        videoPlayer.loopPointReached += OnVideoEnd; // Automatically load next scene when the video ends
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return)) // Detect Enter key press
        {
            SkipCutscene();
        }
    }

    void OnVideoEnd(VideoPlayer vp)
    {
        LoadNextScene();
    }

    void SkipCutscene()
    {
        Debug.Log("Cutscene skipped!");
        videoPlayer.Stop(); // Stop the video playback
        LoadNextScene();
    }

    void LoadNextScene()
    {
        SceneManager.LoadScene(nextSceneName);
    }
}

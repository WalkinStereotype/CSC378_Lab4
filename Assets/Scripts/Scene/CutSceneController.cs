using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class CutsceneController : MonoBehaviour
{
    public VideoPlayer videoPlayer;
    public string videoURL = "https://drive.google.com/file/d/1htV4wbldgOfwOLePHAkh5a8KlLMudtu5/view?usp=sharing";
    public string nextSceneName = "MainMenu"; // Change this to your actual menu scene

    void Start()
    {
        videoPlayer.url = videoURL;
        videoPlayer.Play();
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

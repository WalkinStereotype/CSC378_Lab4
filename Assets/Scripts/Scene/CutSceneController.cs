using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class CutsceneController : MonoBehaviour
{
    public VideoPlayer videoPlayer;
    public string nextSceneName = "MainMenu"; // Change this to your actual Main Menu scene name

    void Start()
    {
        videoPlayer.loopPointReached += OnVideoEnd; // Subscribe to the event
    }

    void OnVideoEnd(VideoPlayer vp)
    {
        SceneManager.LoadScene(nextSceneName); // Load Main Menu when video ends
    }
}

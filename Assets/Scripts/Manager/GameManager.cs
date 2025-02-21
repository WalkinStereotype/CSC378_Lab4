using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public GameObject gameOverScreen; 

    public TextMeshProUGUI gameOverMessage;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        gameOverMessage.text = "You died!";
    }

    // private void Update()
    // {
    //     duration += Time.deltaTime;
    // }

    // public void UpdateLives(int points)
    // {
    //     lives -= points;
    //     livesText.text = "Lives: " + lives.ToString();

    //     if (lives <= 0){
    //         Time.timeScale = 0;
    //         Debug.Log("Game Over");
    //         ShowGameOverScreen();
    //         //Display UI
    //     }
    // }

    public void ShowGameOverScreen(bool didWin)
    {
        Time.timeScale = 0;
        Debug.Log("Game Lose");
        if (didWin)
        {
            gameOverMessage.text = "Success!";
        }
        gameOverScreen.SetActive(true);
    }
    
}


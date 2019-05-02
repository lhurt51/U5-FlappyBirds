using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Accessing scene manager to refresh scene
using UnityEngine.SceneManagement;
// Accessing unitys UI to update score
using UnityEngine.UI;

public class GameControl : MonoBehaviour
{

    // Enforcing the singleton
    public static GameControl   instance;
    // Stroing reference to our game over text
    public GameObject           gameOverText;
    // Storing a refernce to the scores text
    public Text                 scoreText;
    // Storing a refernce to the scores text
    public Text                 highScoreText;
    // Creating a public scrolling speed so it is easy to change (Non neg for convience)
    public float                scrollSpeed = 1.5f;

    // Game over private accessor
    public bool                 BIsGameOver { get => bIsGameOver; }

    // Storing if the game is over or not
    private bool                bIsGameOver = false;
    // Storing the score of the player
    private int                 score = 0;
    // Storing the high score of the player
    private int                 highScore = 0;


    // Called if the player scored
    public void PlayerScored()
    {
        // If game is over dont score
        if (bIsGameOver) return;

        UpdateScore();
    }

    // Applying end game settings and UI
    public void PlayerDied()
    {
        // Enabling our disabled game over text
        gameOverText.SetActive(true);
        // Setting the game over to true
        bIsGameOver = true;
        UpdateHighScore();
    }

#if (UNITY_EDITOR)
    // Reset Highscore only useful for editor
    public void ResetHighScore()
    {
        PlayerPrefs.DeleteKey("HighScore");
        Debug.Log(">> High score was delete!");
    }
#endif

    // Use this for initialization
    private void                Awake()
    {
        // If there is not istance assign this else destory its self
        if (instance == null) instance = this;
        else if (instance != this) Destroy(gameObject);

        // Getting the high score of the current machine, if none default to 0
        highScore = PlayerPrefs.GetInt("HighScore", 0);
        // Updating the highscore string with our high score variable
        highScoreText.text = "High Score: " + highScore.ToString();
    }

    // Update is called once per frame
    private void                Update()
    {
        // If game is over and player presses space refresh scene
        if (bIsGameOver && Input.GetKeyDown(KeyCode.Space))
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    // Update the score + 1
    private void                UpdateScore()
    {
        // Else increament score by one
        score++;
        // Update the text to show score
        scoreText.text = "Score: " + score.ToString();
    }

    // Updates high score if score is greater
    private void                UpdateHighScore()
    {
        // If the score is higher than the high score reset highscore and the display
        if (score > highScore)
        {
            highScore = score;
            PlayerPrefs.SetInt("HighScore", highScore);
            highScoreText.text = "High Score: " + highScore.ToString();
        }
    }
}

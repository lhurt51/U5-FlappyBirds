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
    // Storing a reference to the player object
    public GameObject           playerObject;
    // Storing a reference to our main menu text
    public GameObject           mainMenuText;
    // Storing a reference to our game over text
    public GameObject           gameOverText;
    // Storing a refernce to the scores text
    public Text                 scoreText;
    // Storing a refernce to the high scores text
    public Text                 highScoreText;
    // Storing a refernce to the timer text
    public Text                 timerText;
    // Creating a public scrolling speed so it is easy to change (Non neg for convience)
    public float                scrollSpeed = 1.5f;

    // Game over private accessor
    public bool                 BIsGameOver { get => bIsGameOver; }

    // Storing if the game is over or not
    private bool                bIsGameOver = true;
    // Storing the score of the player
    private int                 score = 0;
    // Storing the high score of the player
    private int                 highScore = 0;
    // Storing the timers time
    private float               startTimer = 10.0f;


    // Called when the game is started
    public void                 StartGame()
    {
        // Disabling the main menu text
        mainMenuText.SetActive(false);
        // Setting game over to false to start the game
        bIsGameOver = false;

        Rigidbody2D rb = playerObject.GetComponent<Rigidbody2D>();
        if (rb) rb.isKinematic = false;
    }

    // Called if the player scored
    public void                 PlayerScored()
    {
        // If game is over dont score
        if (bIsGameOver) return;

        UpdateScore();
    }

    // Applying end game settings and UI
    public void                 PlayerDied()
    {
        // Enabling our game over text
        gameOverText.SetActive(true);
        // Setting the game over to true
        bIsGameOver = true;
        UpdateHighScore();
    }

#if (UNITY_EDITOR)
    // Reset Highscore only useful for editor
    public void                 ResetHighScore()
    {
        // Deleting the key
        PlayerPrefs.DeleteKey("HighScore");
        // printing a log
        Debug.Log(">> High score was delete!");
    }
#endif

    // Use this for initialization
    private void                Awake()
    {
        // If there is not istance assign this else destory its self
        if (instance == null) instance = this;
        else if (instance != this) Destroy(gameObject);

        // Set the rigid body to be kinematic till game starts
        Rigidbody2D rb = playerObject.GetComponent<Rigidbody2D>();
        if (rb) rb.isKinematic = true;
    }

    // Start is called before the first frame update
    private void                Start()
    {
        startTimer = 10.0f;
        // Getting the high score of the current machine, if none default to 0
        highScore = PlayerPrefs.GetInt("HighScore", 0);
        // Updating the highscore string with our high score variable
        UpdateHighScoreText();
    }

    // Update is called once per frame
    private void                Update()
    {
        if (startTimer > 0.0f)
        {
            // Subracting the timer with delta time
            startTimer -= Time.deltaTime;
            // Updating the timer text string
            timerText.text = ((int)startTimer).ToString();
            // Checking for start game
            if (startTimer <= 0.0f) StartGame();
        }
        // If game is over and player presses space refresh scene
        else if (bIsGameOver && Input.GetKeyDown(KeyCode.Space))
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    // Update the score + 1, then update text
    private void                UpdateScore()
    {
        // Else increament score by one
        score++;
        UpdateScoreText();
    }

    // Update the scores text
    private void                UpdateScoreText()
    {
        // Update the text to show score
        scoreText.text = "Score: " + score.ToString();
    }

    // Update the high scores text
    private void                UpdateHighScoreText()
    {
        // Update the text to show high score
        highScoreText.text = "High Score: " + highScore.ToString();
    }

    // Updates high score if score is greater
    private void                UpdateHighScore()
    {
        // If the score is higher than the high score reset highscore and the display
        if (score > highScore)
        {
            highScore = score;
            PlayerPrefs.SetInt("HighScore", highScore);
            UpdateHighScoreText();
        }
    }
}

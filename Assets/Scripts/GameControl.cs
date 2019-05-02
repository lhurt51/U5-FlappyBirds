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
    public static GameControl instance;
    // Stroing reference to our game over text
    public GameObject gameOverText;
    // Storing a refernce to the scores text
    public Text scoreText;
    // Creating a public scrolling speed so it is easy to change (Non neg for convience)
    public float scrollSpeed = 1.5f;

    // Storing if the game is over or not
    private bool bIsGameOver = false;
    // Storing the score of the player
    private int score = 0;

    // Game over accessor
    public bool BIsGameOver { get => bIsGameOver; }

    // Use this for initialization
    void Awake()
    {
        // If there is not istance assign this else destory its self
        if (instance == null) instance = this;
        else if (instance != this) Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        // If game is over and player presses space refresh scene
        if (bIsGameOver && Input.GetKeyDown(KeyCode.Space))
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void PlayerScored()
    {
        if (bIsGameOver) return;
        score++;
        scoreText.text = "Score: " + score.ToString();
    }

    // Applying end game settings and UI
    public void PlayerDied()
    {
        // Enabling our disabled game over text
        gameOverText.SetActive(true);
        // Setting the game over to true
        bIsGameOver = true;
    }
}

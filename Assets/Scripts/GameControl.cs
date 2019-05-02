using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// Accessing scene manager to refresh scene
using UnityEngine.SceneManagement;

public class GameControl : MonoBehaviour
{

    // Enforcing the singleton
    public static GameControl instance;
    // Stroing reference to our game over text
    public GameObject gameOverText;

    // Storing if the game is over or not
    private bool bIsGameOver = false;

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

    // Applying end game settings and UI
    public void PlayerDied()
    {
        // Enabling our disabled game over text
        gameOverText.SetActive(true);
        // Setting the game over to true
        bIsGameOver = true;
    }
}

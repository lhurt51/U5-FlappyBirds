using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColumnPool : MonoBehaviour
{

    // Stroing the how many columns to pool
    public int              columnPoolSize = 5;
    // Storing the comun prefab
    public GameObject       columnPrefab;
    // The rate at witch new columns spawn
    public float            spawnRate = 4.0f;
    // The min y pos that the column can be placed at
    public float            columnMin = -2.2f;
    // The max y pos that the column can be placed at
    public float            columnMax = 1.0f;

    // The array of our columns
    private GameObject[]    columns;
    // Where to spawn the pooled columns
    private Vector2         objectPoolPos = new Vector2(-15.0f, -25.0f);
    // Time since the last comun was spawned
    private float           timeSinceLastSpawn;
    // Constant x pos to spawn the column at off screen
    private float           spawnXPos = 10.0f;
    // Current column we are changing
    private int             currentColumn = 0;

    // Start is called before the first frame update
    private void            Start()
    {
        // Creating and initializing our columns array
        columns = new GameObject[columnPoolSize];
        for (int i = 0; i < columnPoolSize; i++)
            columns[i] = (GameObject)Instantiate(columnPrefab, objectPoolPos, Quaternion.identity);
    }

    // Update is called once per frame
    private void            Update()
    {
        // Calculating how much time has passed
        timeSinceLastSpawn += Time.deltaTime;
        // Checking that game is not over and a new column should be spawned
        if (GameControl.instance.BIsGameOver == false && timeSinceLastSpawn >= spawnRate)
        {
            // Reset spawn timer
            timeSinceLastSpawn = 0.0f;
            // Calculate rand Y pos within range
            float spawnYPos = Random.Range(columnMin, columnMax);
            // Changing the selected columns position
            columns[currentColumn].transform.position = new Vector2(spawnXPos, spawnYPos);
            // Increasing the current column and checking if it is withing the correct range
            currentColumn++;
            if (currentColumn >= columnPoolSize) currentColumn = 0;
        }
    }
}

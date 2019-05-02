using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingObject : MonoBehaviour
{
    // Storing a copy of our rigid body component
    private Rigidbody2D rigidBody2D;

    // Start is called before the first frame update
    void                Start()
    {
        // Making sure we have a rigid body component and storing it
        rigidBody2D = GetComponent<Rigidbody2D>();
        // Setting the velocity.x to the scroll speed
        rigidBody2D.velocity = new Vector2(-GameControl.instance.scrollSpeed, 0.0f);
    }

    // Update is called once per frame
    void                Update()
    {
        // If the game is over stop scrolling
        if (GameControl.instance.BIsGameOver)
            rigidBody2D.velocity = Vector2.zero;
        // Setting the velocity.x to the scroll speed
        else if (!GameControl.instance.BIsGameOver && rigidBody2D.velocity == Vector2.zero)
            rigidBody2D.velocity = new Vector2(-GameControl.instance.scrollSpeed, 0.0f);
    }
}

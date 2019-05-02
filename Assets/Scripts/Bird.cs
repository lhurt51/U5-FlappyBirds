using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour
{
    // Up force of players input (defined in editor)
    public float upForce = 200.0f;

    // Checks if the player is dead
    private bool bIsDead = false;
    // Storing a copy of our rigid body component
    private Rigidbody2D rigidBody2D;
    // Storing a copy of the bird animator
    private Animator birdAnim;

    // Start is called before the first frame update
    void Start()
    {
        // Making sure we have a rigid body component and storing it
        rigidBody2D = GetComponent<Rigidbody2D>();
        // Making sure we have a animator component and storing it
        birdAnim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        // If bird is dead end update
        if (bIsDead == true) return;

        // If User presses space
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // Make sure zero the velocity for clean interpolation
            rigidBody2D.velocity = Vector2.zero;
            // Adding an upward force of up force
            rigidBody2D.AddForce(new Vector2(0, upForce));
            // Calling the falp animation trigger
            birdAnim.SetTrigger("Flap");
        }
    }

    // Unity's Collision overide
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Setting the bird to dead
        bIsDead = true;
        // Calling the dead animation trigger
        birdAnim.SetTrigger("Die");
        // Calling the player died function
        GameControl.instance.PlayerDied();
    }
}

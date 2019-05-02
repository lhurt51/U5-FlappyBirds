using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndlessWorld : MonoBehaviour
{

    // A reference to the ground collider component
    private BoxCollider2D groundCollider;
    // The ground objects width
    private float groundWidth;

    // Start is called before the first frame update
    void Start()
    {
        // Looking for a reference of a BoxCollider and storing it
        groundCollider = GetComponent<BoxCollider2D>();
        // Storing the size of the colliders width
        groundWidth = groundCollider.size.x;
    }

    // Update is called once per frame
    void Update()
    {
        // If this ground object is off screen
        if (transform.position.x < -groundWidth)
        {
            // Reposition the back ground
            ReposBackGround();
        }
    }

    // Moving the back ground infront of camera (x-axis movement)
    private void ReposBackGround()
    {
        // Calculate the new pos of the ground based on width
        Vector2 groundOffset = new Vector2(groundWidth * 2.0f, 0.0f);
        // Calculating the new pos for the grounp pos
        transform.position = (Vector2)transform.position + groundOffset;
    }
}

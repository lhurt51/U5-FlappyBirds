using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Column : MonoBehaviour
{

    // Checks for collision with the goal trigger
    private void OnTriggerEnter2D(Collider2D other)
    {
        // Checking to see if it is our bird object
        if (other.GetComponent<Bird>() != null)
        {
            // Calles player scored to increase score
            GameControl.instance.PlayerScored();
        }
    }

}

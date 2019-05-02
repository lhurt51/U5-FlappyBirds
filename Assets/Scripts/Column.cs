using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Column : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Checking to see if it is our bird object
        if (other.GetComponent<Bird>() != null)
        {
            GameControl.instance.PlayerScored();
        }
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour
{

    public float upForce = 200.0f;

    private bool bIsDead = false;
    private Rigidbody2D rigidBody2D;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (bIsDead == false)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                rigidBody2D.velocity = Vector2.zero;
                rigidBody2D.AddForce(new Vector2(0, upForce));
            }
        }
    }
}

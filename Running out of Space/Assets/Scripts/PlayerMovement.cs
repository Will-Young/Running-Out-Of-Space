using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    Rigidbody2D rb;

    public float speed = 7.5f;

    float moveHorizontal;
    float moveVertical;

    Vector2 movement;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();

    }
	
	// Update is called once per frame
	void Update () {
        Movement();
        //Rotation();
	}

    // Movement of player
    void Movement()
    {
        moveHorizontal = Input.GetAxis("Horizontal");
        moveVertical = Input.GetAxis("Vertical");

        movement = new Vector2(moveHorizontal, moveVertical);

        rb.velocity = movement * speed;
    }

    // Rotation of player
    void Rotation()
    {
        // Find mouse position
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        // Rotate charcter to face mouse
        transform.rotation = Quaternion.LookRotation(Vector3.forward, mousePos - transform.position);
    }
}

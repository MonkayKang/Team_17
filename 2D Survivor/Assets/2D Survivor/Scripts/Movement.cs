using Goldmetal.UndeadSurvivor;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    // Player
    public GameObject player;

    // Weapon
    public GameObject weapon;

    // Rigidbody2D
    private Rigidbody2D _rb2d;

    // Variable for the Animator
    private Animator _anim;

    // Variable for SpriteRenderer
    private SpriteRenderer _sr;
    public SpriteRenderer _sr2;

    // Is the character moving
    bool isMoving = false;

    // Speed of movement
    public float moveSpeed = 5f;

    private float cash;

    // Start is called before the first frame update
    void Start()
    {
        // Initialize Unity's Rigidbody2D
        _rb2d = GetComponent<Rigidbody2D>();

        // Initialize the Animator
        _anim = GetComponent<Animator>();

        _sr = GetComponent<SpriteRenderer>();
        _sr2 = GetComponent<SpriteRenderer>();
    }

    // FixedUpdate is called once per physics update
    private void FixedUpdate()
    {
        // Check for movement input
        float moveX = Input.GetAxis("Horizontal");
        float moveY = Input.GetAxis("Vertical");

        // Set the movement
        Vector2 movement = new Vector2(moveX, moveY);

        // Move the player
        _rb2d.velocity = movement * moveSpeed;

        // Check if the player is moving
        isMoving = movement.magnitude > 0;

        // Update the animator
        _anim.SetBool("isRunning", isMoving);

        // Flip the sprite based on movement direction
        if (moveX < 0)
        {
            _sr.flipX = true;
        }
        else if (moveX > 0)
        {
            _sr.flipX = false;
        }
    }

    // When Grabbing a Coin
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Coin")) // Collect Cash
        {
            ScoreDisplay.score += 10f;
            Destroy(collision.gameObject); // Destroy
        }
    }
}

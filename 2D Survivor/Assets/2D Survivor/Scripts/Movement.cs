using Goldmetal.UndeadSurvivor;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Windows.WebCam;

public class Movement : MonoBehaviour
{
    // Player
    public GameObject player;

    // Weapon
    public GameObject weapon;

    // Disable Weapon
    public GameObject weapon1;
    public GameObject weapon2;
    public GameObject weapon3;
    public GameObject weapon4;

    // 2D Collider
    public CapsuleCollider2D capsule;

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

    // Audio
    public AudioClip deathSound; // Death sound clip
    public AudioSource audioSource;
    public AudioSource CameraSource; // Stop Music
    private bool hasPlayedDeathSound;

    // Health
    public Slider health;
    public float regen = 0.5f;
    public float regenInterval = 1f; // Regen Interal
    private float regenCooldown; // Cooldown

    // Health reduction rate
    public float damageRate = 0.5f; // Damage per second

    // Reset
    public GameObject Reset;

    // Start is called before the first frame update
    void Start()
    {
        // Initialize Unity's Rigidbody2D
        _rb2d = GetComponent<Rigidbody2D>();

        // Initialize the Animator
        _anim = GetComponent<Animator>();

        _sr = GetComponent<SpriteRenderer>();
        _sr2 = GetComponent<SpriteRenderer>();

        capsule = GetComponent<CapsuleCollider2D>();
    }

    // FixedUpdate is called once per physics update
    private void FixedUpdate()
    {
        // Check for movement input
        float moveX = Input.GetAxis("Horizontal");
        float moveY = Input.GetAxis("Vertical");

        // Set the movement
        Vector2 movement = new Vector2(moveX, moveY);

        if (!hasPlayedDeathSound) // If player hasnt died
        {
            // Move the player
            _rb2d.velocity = movement * moveSpeed;
        }
        if (hasPlayedDeathSound) // If player has died
        {
            // stop the player
            _rb2d.velocity = movement * 0;
        }


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

        if (health.value < 100 && regenCooldown <= 0)
        {
            health.value += regen;
            regenCooldown = regenInterval; // Reset the timer
        }
        else
        {
            regenCooldown -= Time.deltaTime; // Countdown the timer
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

        if (collision.gameObject.CompareTag("Enemy")) // If colliding with enemy
        {
            // Reduce the health slowly 
            health.value -= damageRate * Time.deltaTime;

            // Prevents health from going past 0
            if (health.value <= 0)
            {
                health.value = 0;
                _anim.SetBool("isDead", true);// Death animation

                // Stop Audio
                CameraSource.enabled = false;
                // Play Audio 
                if (!hasPlayedDeathSound)
                {
                    audioSource.PlayOneShot(deathSound);
                    hasPlayedDeathSound = true; // Mark that the sound has been played
                    Reset.SetActive(true); // Bring up the reset Button
                }

                // Stops the Collision
                weapon1.SetActive(false); 
                weapon2.SetActive(false);
                weapon3.SetActive(false);
                weapon4.SetActive(false);
                capsule.enabled = false;
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using Unity.PlasticSCM.Editor.WebApi;
using UnityEngine;
using UnityEngine.UIElements;

public class EnemyMovement : MonoBehaviour
{
    // Declare the variables
    public GameObject player;
    public float speed;

    // Distance from player
    private float distance;

    // Animator
    private Animator _anim;

    // Sprite Renderer 
    private SpriteRenderer _sr;

    // Hit Counter
    private float hitCounter;

    private bool Dead = false;

    // Coin
    public GameObject coin;

    // Collision
    private CapsuleCollider2D _col;


    // Start is called before the first frame update
    void Start()
    {
        // Intialize the sprite renderer
        _sr = GetComponent<SpriteRenderer>();

        // Find the player by tag
        player = GameObject.FindWithTag("Player");

        // Initialize the Animator
        _anim = GetComponent<Animator>();

        //Initialize the collider
        _col = GetComponent<CapsuleCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!Dead) // Stops them from moving after death
        {
            // Calculates the distance between player and enemy
            distance = Vector2.Distance(transform.position, transform.position);
            // move towards them
            transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, speed * Time.deltaTime);

            // Get the direction to the player
            Vector2 direction = player.transform.position - transform.position;


            // Flip Sprite depending where it's facing
            if (direction.x > 0)
            {
                _sr.flipX = false;
            }
            else if (direction.x < 0)
            {
                _sr.flipX = true;
            }

            if (hitCounter > 1) // Hit more than once
            {
                // Update the animator
                _anim.SetBool("isDead", true);
                Dead = true;
                ScoreDisplay.killcount++;
                _col.enabled = false;
                // Start Countdown
                StartCoroutine(Wait());
            }
        }
    }
        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.CompareTag("Player")) // Look for if hit by weapon
            {
                _anim.SetTrigger("isHit"); // set to true
                hitCounter++;
            }

            if (collision.gameObject.CompareTag("Bullet")) // Look for if hit by Bullet
            {
                _anim.SetTrigger("isHit"); // set to true
                hitCounter++;
                Destroy(collision.gameObject);
            }
        }

        private IEnumerator Wait() // Wait before destruction
        {
            // Wait for 2 seconds
            yield return new WaitForSeconds(2f);
            Instantiate(coin, transform.position, Quaternion.identity); // spawn a coin at death
            Destroy(this.gameObject); // Destroy itself
            _anim.SetTrigger("isHit"); 
        }
    
}

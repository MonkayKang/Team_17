using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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


    // Start is called before the first frame update
    void Start()
    {
        // Intialize the sprite renderer
        _sr = GetComponent<SpriteRenderer>();

        // Find the player by tag
        player = GameObject.FindWithTag("Player");

        // Initialize the Animator
        _anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!Dead)
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
        }

        private IEnumerator WaitAfterHit()
        {
            // Wait for 3 seconds
            yield return new WaitForSeconds(1f);
            _anim.SetTrigger("isHit");
        }
    
}

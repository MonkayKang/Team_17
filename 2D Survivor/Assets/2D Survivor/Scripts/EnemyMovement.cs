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


    // Sprite Renderer 
    private SpriteRenderer _sr;


    // Start is called before the first frame update
    void Start()
    {
        // Intialize the sprite renderer
        _sr = GetComponent<SpriteRenderer>();

        // Find the player by tag
        player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
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
    }
}

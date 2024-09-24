using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    // Player
    public GameObject player;

    // Rigidbody2D
    private Rigidbody2D _rb2d;

    // Variable for the Animator
    private Animator _anim;

    // Varaible for SpriteRenderer
    private SpriteRenderer _sr;

    // Is the character moving
    bool ismoving = false;

    // Start is called before the first frame update
    void Start()
    {
        // Initalize Unity's Rigidbody2D
        _rb2d = GetComponent<Rigidbody2D>();

        // Intialize the Animator
        _anim = GetComponent<Animator>();

        _sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per last frame
    private void FixedUpdate()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ismoving = Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.W);
        while (ismoving)
        {
            _anim.SetBool("isRunning", true);
        }
    }
}

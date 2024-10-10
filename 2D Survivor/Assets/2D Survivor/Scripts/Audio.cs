using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio : MonoBehaviour
{
    // Audio
    public AudioClip clip;
    public AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        GameObject player = GameObject.Find("Player"); // Find Player
        audioSource = player.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        audioSource.PlayOneShot(clip);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        audioSource.PlayOneShot(clip);
    }
}

using Goldmetal.UndeadSurvivor;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponFollow : MonoBehaviour
{
    public Camera mainCamera; // Reference to the main camera
    public Transform weaponTransform; // The transform of the sword
    public Transform playerTransform; // The transform of the player
    public GameObject bulletprefab; // Bullet prefab

    // A small offset to position the weapon
    public float weaponOffsetX = 0.22f;

    // Is the weapon a gun?
    public bool isGun = false;
    public bool isSmg = false;

    // SMG shooting speed
    public float smgFireRate = 0.1f; // Seconds between bullets for SMG
    private float nextSmgFireTime = 0f; // Timer for SMG fire rate

    // Bullet shooting force and angles for the shotgun
    public float bulletSpeed = 10f;
    public float bulletSpreadAngle = 15f; // The angle spread for the shotgun bullets

    // Audio
    public AudioClip fire; // bullet SFX
    public AudioClip smg; 
    public AudioSource audioSource;



    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // Get the position of the mouse in world space
        Vector3 mousePosition = Input.mousePosition;
        mousePosition = mainCamera.ScreenToWorldPoint(mousePosition);
        mousePosition.z = 0;

        // Calculate the direction from the weapon to the mouse
        Vector3 direction = mousePosition - weaponTransform.position;

        // Calculate the rotation angle in degrees
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        // Apply the rotation to the weapon
        weaponTransform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));

        // Adjust the weapon position based on the mouse position relative to the player
        if (mousePosition.x > playerTransform.position.x) // Mouse is to the right of the player
        {
            weaponTransform.position = new Vector3(playerTransform.position.x + weaponOffsetX, weaponTransform.position.y, weaponTransform.position.z);
        }
        else // Mouse is to the left of the player
        {
            weaponTransform.position = new Vector3(playerTransform.position.x - weaponOffsetX, weaponTransform.position.y, weaponTransform.position.z);
        }

        // If it is a gun, Shoot
        if (isGun && Input.GetMouseButtonDown(0))
        {
            audioSource.PlayOneShot(fire);

            for (int i = -1; i <= 1; i++)
            {
                audioSource.PlayOneShot(fire);
                // Calculate the direction of the bullet with some spread
                float spread = i * bulletSpreadAngle; // -bulletSpreadAngle, 0, bulletSpreadAngle
                Quaternion rotation = Quaternion.Euler(new Vector3(0, 0, weaponTransform.eulerAngles.z + spread));

                // Instantiate the bullet
                GameObject bullet = Instantiate(bulletprefab, weaponTransform.position, rotation) ;

                // Set the velocity of the bullet
                Rigidbody2D rb = bullet.GetComponentInChildren<Rigidbody2D>();
                rb.velocity = bullet.transform.right * bulletSpeed;
            }
        }
        if (smg && Input.GetMouseButton(0)) // When the fire button is held down
        {
            if (!audioSource.isPlaying) // If the SMG sound isn't playing, start it
            {
                audioSource.clip = smg;
                audioSource.loop = true; // Loop the sound for continuous fire
                audioSource.Play();
            }

            if (Time.time >= nextSmgFireTime) // Fire the SMG bullet
            {
                // Create one bullet going straight forward
                GameObject bullet = Instantiate(bulletprefab, weaponTransform.position, weaponTransform.rotation);

                // Set the velocity of the bullet
                Rigidbody2D rb = bullet.GetComponentInChildren<Rigidbody2D>();
                rb.velocity = bullet.transform.right * bulletSpeed;

                nextSmgFireTime = Time.time + smgFireRate;
            }
        }
        else if (audioSource.isPlaying) // Stop the SMG sound when the fire button is released
        {
            audioSource.Stop();
        }
    }

}
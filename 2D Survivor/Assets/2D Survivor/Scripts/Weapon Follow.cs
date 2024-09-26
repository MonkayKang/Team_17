using Goldmetal.UndeadSurvivor;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponFollow : MonoBehaviour
{
    public Camera mainCamera; // Reference to the main camera
    public Transform weaponTransform; // The transform of the sword
    public Transform playerTransform; // The transform of the player

    // A small offset to position the weapon
    public float weaponOffsetX = 0.22f;

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
    }
}
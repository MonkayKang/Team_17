using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    // Camera will lock on to the specific target
    public Transform target;

    // Smooth movement variables
    public float smoothRate = 1.5f;
    public Vector3 offset = Vector3.zero;

    // Start is called before the first frame update
    void Start()
    {
        // Move the Camera towards the target (Player)
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Called once per frame after everything else has been updated
    private void LateUpdate()
    {
        // Get the target position 
        Vector3 targetPos = new Vector3(target.position.x, target.position.y, transform.position.z);

        // Lerp means "linear interpolation" Learned it from Last Semester.
        // Smoothly move the camera towards the target's position
        // Time.deltatime is relative to the frame rate with the "smooth rate" to make the image not "jittery"
        transform.position = Vector3.Lerp(transform.position, targetPos + offset, Time.deltaTime * smoothRate);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
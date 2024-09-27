using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    // Grab Script
    public MonoBehaviour script;

    // Start is called before the first frame update
    void Start()
    {
        script.enabled = false; // Dont disable the object but the script itself
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > 5)
        {
            script.enabled = true; // return it here
        }
    }
}

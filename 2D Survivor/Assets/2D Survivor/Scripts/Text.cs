using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // Importing the UI namespace

public class ScoreDisplay : MonoBehaviour
{
    // Text Input
    public Text text2; // Text component for displaying score
    public Text Kills;

    // Stats
    public static float score;
    public static float killcount;

    // Start is called before the first frame update
    void Start()
    {
        // Optionally, initialize score or other variables here
    }

    // Update is called once per frame
    void Update()
    {
        // Update the text components with current score
        text2.text = ":" + score.ToString(); 
        Kills.text = killcount.ToString();

    }
}

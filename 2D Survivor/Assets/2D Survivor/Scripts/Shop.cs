using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    // How much money to buy weapon
    public float money;

    // Grab the button
    public Button button;

    // Start is called before the first frame update
    void Start()
    {
        // Initialize
        button = GetComponent<Button>();
    }

    // Update is called once per frame
    void Update()
    {
        // If the player has enough money
        if (ScoreDisplay.score >= money)
        {
            button.interactable = true; // they can purchase it
        }
    }

    public void Purchase()
    {
        ScoreDisplay.score -= money;
        button.interactable = false;
    }
}

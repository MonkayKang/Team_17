using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    // This Code Is mainly from a previous Class
    // Refer to itself
    public static GameManager instance;

    // GameState enumerator that is holding two possible game states
    public enum gameState { pause, play };

    //Seperate variable to track which item of the enum to use
    public gameState currentState;

    public Slider slider;


    private void Awake()
    {
        // Make sure there is only one GameManager. If it exsist already, destroy this
        if (instance == null)
        {
            instance = this;
        }

        // If it already exsist, destroy this gameObject
        else
        {
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        // Start the Game with it paused
        currentState = gameState.pause;
    }

    // Update is called once per frame
    void Update()
    {
        switch (currentState)
        {
            // Pause turns the time to 0
            // Play turns it back to one
            case gameState.pause:
                Time.timeScale = 0;
                break;

            case gameState.play:
                Time.timeScale = 1;
                break;

        }
        if (slider.value <= 0)
        {
            StartCoroutine(Wait());
        }
    }

    public void StartGame()
    {
        // Play
        currentState = gameState.play;
    }
    public void StopGame()
    {
        //Pause
        currentState = gameState.pause;
    }

    private IEnumerator Wait() // Wait before destruction
    {
        // Wait for 2 seconds
        yield return new WaitForSeconds(1f);
        currentState = gameState.pause;
    }
}

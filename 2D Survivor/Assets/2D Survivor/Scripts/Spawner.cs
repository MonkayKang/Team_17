using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    // Spawn Cooldown
    public float spawninterval = 5;

    // Enemies
    public GameObject enemy1;
    public GameObject enemy2;
    public GameObject enemy3;
    public GameObject enemy4;

    // Spawn Timer
    private float nextspawn;

    // Start is called before the first frame update
    void Start()
    {
    
        nextspawn = Time.time + spawninterval;
    }

    // Update is called once per frame
    void Update()
    {
        // Once the time reaches the coldown
        if (Time.time > nextspawn)
        {
            // Generate a new random number
            int rand = Random.Range(1, 5);

            // Make a random number
            int randObj = Random.Range(0, 10);

            // Spawn enemy relative to the number chosen
            switch(randObj)
            {
                case 0: 
                    Instantiate(enemy1, transform.position, Quaternion.identity);
                    break;
                case 1:
                    Instantiate(enemy2, transform.position, Quaternion.identity);
                    break;
                case 2:
                    Instantiate(enemy1, transform.position, Quaternion.identity);
                    break;
                case 3:
                    Instantiate(enemy2, transform.position,Quaternion.identity);
                    break;
                case 4:
                    Instantiate(enemy3 , transform.position, Quaternion.identity);
                    break;
                case 5:
                    Instantiate(enemy4 , transform.position, Quaternion.identity);
                    break;
                case 6: 
                    Instantiate(enemy1 , transform.position, Quaternion.identity);
                    break;
                case 7:
                    Instantiate(enemy2 , transform.position, Quaternion.identity);
                    break;
                case 8:
                    Instantiate(enemy3, transform.position, Quaternion.identity);
                    break;
                case 9:
                    Instantiate(enemy1, transform.position, Quaternion.identity);
                    break;
                case 10:
                    Instantiate(enemy4, transform.position, Quaternion.identity);
                    break;
            }
            // Random next spawn (Prevents being predictable
            nextspawn = Time.time + spawninterval + rand;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public GameObject obstacle;
    public Transform spawnPoint;
    int score = 0;
    public TextMeshProUGUI scoreText;
    public GameObject playButton;
    public GameObject player;


    // Start is called before the first frame update
    void Start()
    {
        // GameStart();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator SpawnObstacles()
    {
        while (true)
        {
            // this will generate random numbers 
            float waitTime = Random.Range(0.8f, 2f);

            // this will made obstacle wait for random number of time
            yield return new WaitForSeconds(waitTime);

            // this will respawn the obstacle
            Instantiate(obstacle, spawnPoint.position, Quaternion.identity);
        }
    }

    void ScoreUp()
    {
        score++;
        scoreText.text = score.ToString();
    }


    // what happen when the game will start
    public void GameStart()
    {
        player.SetActive(true);
        playButton.SetActive(false);
        StartCoroutine("SpawnObstacles");
        InvokeRepeating("ScoreUp", 2f, 1f); // call ScoreUp function after 2 second then every 1 second call ScoreUp function recursively
    }
  
}

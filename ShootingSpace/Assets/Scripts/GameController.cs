using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

    public GameObject[] hazards;
    public Vector3 spawnValue;
    public int hazardCount;
    public float spawnWait;
    public float startWait;
    public float waveWait;

    public Text scoreText;
    private int score;
    //public Text restartText;
    public Text gameOverText;
    public GameObject restartButton;

    private bool gameOver;
    private bool restart;

    private void Start()
    {
        gameOver = false;
        restart = false;
        //restartText.text = "";
        restartButton.SetActive(false);
        gameOverText.text = "";
        score = 0;
        UpdateScore();
        StartCoroutine(SpawnWaves());
    }

    //private void Update()
    //{
    //    if (restart)
    //    {
    //        if (Input.GetKeyDown(KeyCode.R))
    //        {
    //            SceneManager.LoadScene("Main");
    //        }
    //    }
    //}

    IEnumerator SpawnWaves()
    {
        yield return new WaitForSeconds(startWait);
        while (true)
        {
            for (int i = 0; i < hazardCount; i++)
            {
                GameObject hazard = hazards[Random.Range(0,hazards.Length)];
                Vector3 min = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, 0));
                Vector3 max = Camera.main.ViewportToWorldPoint(new Vector3(1, 1.05f, -0.05f));
                Vector3 spawnPosition = new Vector3(Random.Range(min.x,max.x), 0, max.z);
                Quaternion spawnRotation = Quaternion.identity;
                Instantiate(hazard, spawnPosition, spawnRotation);
                yield return new WaitForSeconds(spawnWait);
            }
            yield return new WaitForSeconds(waveWait);

            if (gameOver)
            {
                //restartText.text = "Press 'R' for Restart";
                restartButton.SetActive(true);
                restart = true;
                break;
            }
        }
    }

    public void AddScore(int newScoreValue)
    {
        score += newScoreValue;
        Debug.Log("score = " + score);

        UpdateScore();
    }

    void UpdateScore()
    {
        scoreText.text = "Score : " + score.ToString(); ;
    }

    public void GameOver()
    {
        gameOverText.text = "Game Over";
        gameOver = true;
    }

    public void RestartGame()
    {
        SceneManager.LoadScene("Main");
    }
}

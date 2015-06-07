using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameController : MonoBehaviour
{
    public GameObject hazard;
    public Text scoreText;
    public Text restartText;
    public Text gameOverText;
    public Vector3 spawnValue;
    public int hazardCount;
    public float spawnWait;
    public float startWait;
    public float waveWait;

    private int score;
    private bool gameOver;
    private bool restart;

    public void AddScore(int newScorevalue)
    {
        score += newScorevalue;
        UpdateScore();
    }

    public void GameOver()
    {
        gameOverText.text = "Game Over";
        gameOver = true;

    }

    private void Start()
    {
        StartCoroutine(SpawnWaves());
        score = 0;
        UpdateScore();
        gameOver = false;
        restart = false;
        gameOverText.text = "";
        restartText.text = "";
    }

    private void UpdateScore()
    {
        scoreText.text = "Score: " + score;

    }

    private IEnumerator SpawnWaves()
    {
        yield return new WaitForSeconds(startWait);
        while (true)
        {
            for (int i = 0; i < hazardCount; i++)
            {
                Vector3 spawnPosition = new Vector3(Random.Range(-spawnValue.x, spawnValue.x), spawnValue.y, spawnValue.z);
                Quaternion spawnRotation = Quaternion.identity;
                Instantiate(hazard, spawnPosition, spawnRotation);
                yield return new WaitForSeconds(spawnWait);
            }
            yield return new WaitForSeconds(waveWait);

            if(gameOver)
            {
                restartText.text = "Press 'R' for Restart";
                restart = true;
                break;
            }
        }
    }

    private void Update()
    {
        if(restart)
        {
            if(Input.GetKeyDown(KeyCode.R))
            {
                Application.LoadLevel(Application.loadedLevel);
            }
        }
    }


}

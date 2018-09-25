using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public GameObject hazard;
    public Vector3 SpawnValues;
    public int hazardCount;
    public float SpawnWait;
    public float StartWait;
    public float WaveWait;
    public Text scoreText;
    private int Score;
    public Text RestartTxt;
    public Text GameOverTxt;
    private bool GameOver;
    private bool Restart;

    void Start()
    {
        GameOver = false;
        Restart = false;
        RestartTxt.text = "";
        GameOverTxt.text = "";
        StartCoroutine(SpawnWaves());
        Score = 0;
        UpdateScore();
    }
    void Update()
    {
        if (Restart)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                //Application.LoadLevel(Application.loadedLevel);
                SceneManager.LoadScene("Main");
            }
        }
    }
    void UpdateScore()
    {
        scoreText.text = "Score:" + Score;
    }

    public void AddScore(int newscorevalue)
    {
        Score += newscorevalue;
        UpdateScore();
    }

    IEnumerator SpawnWaves()
    {
        yield return new WaitForSeconds(StartWait);
        while (true)
        {
            for (int i = 0; i < hazardCount; i++)
            {
                Vector3 spawnPosition = new Vector3(Random.Range(-5.0f, 5.0f), SpawnValues.y, SpawnValues.z);
                Quaternion spawnRotation = Quaternion.identity;
                Instantiate(hazard, spawnPosition, spawnRotation);
                yield return new WaitForSeconds(SpawnWait);
            }
            yield return new WaitForSeconds(WaveWait);
            if (GameOver)
            {
                break;
            }
        }
    }
    public void Gameover()
    {
        GameOverTxt.text = "Game Over!";
        GameOver = true;
        RestartTxt.text = "Press 'R' to Restart";
        Restart = true;
    }
}

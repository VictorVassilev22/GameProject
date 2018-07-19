using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class GameController : MonoBehaviour {

    public GameObject hazard;
    public Vector2 spawnValues;
    private Button restart;
    private Button play;
    private Button pause;

    private bool gameRunning = true;
    private bool canSpawn = true;
    private bool canScore = true;

    public float cooldown = 1.0f;
    public float score = 0.0f;
    public float highScore = 0.0f;
    public int enemiesPassed = 0;
    private float savedSpeed;

    public Text showScore;
    public Text showHighScore;
    public Text enemiesPassedText;
    public Text gameOverTxt;

    private Vector2 lastPos = new Vector2();
    private ShootMissle shoot;
    private RollingScript rollScr;

    private void Start()
    {
        showHighScore.text = PlayerPrefs.GetInt("Text(3)", 0).ToString();
        shoot = GameObject.Find("Player").GetComponent<ShootMissle>();
        restart = GameObject.Find("Restart").GetComponent<Button>();
        play = GameObject.Find("Play").GetComponent<Button>();
        pause = GameObject.Find("Pause").GetComponent<Button>();
        pause.onClick.AddListener(Pause);
        play.onClick.AddListener(Play);
        restart.enabled = false;
        restart.GetComponent<Image>().enabled = false;
        restart.onClick.AddListener(RestartGame);
        rollScr = GameObject.Find("Street").GetComponent<RollingScript>();
    }

    void Update()
    {
        if(gameRunning&&canSpawn)
        SpawnWaves();

        if(canScore)
        score += 0.1f;

        if(cooldown>1.0f)
        cooldown-=0.0002f;

        int intScore = (int)score;
        showScore.text = (intScore).ToString();
        if (score> PlayerPrefs.GetInt("Text(3)", 0))
        {
            PlayerPrefs.SetInt("Text(3)", intScore);
            showHighScore.text = intScore.ToString();
        }

        enemiesPassedText.text = enemiesPassed.ToString();

        if (enemiesPassed >= 10)
        {
            EndGame();
        }
    }

    void SpawnWaves()
    {
        for (int i = 0; i <=(int)score/1000; i++)
        {
            Vector2 spawnPosition = new Vector2(UnityEngine.Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y);
            Quaternion spawnRotation = Quaternion.identity;

            if(lastPos.x-spawnPosition.x>=2.7f||i==0)
            Instantiate(hazard, spawnPosition, spawnRotation);

            lastPos = spawnPosition;
        }
        StartCoroutine(StartCooldown());
    }

    void EndGame()
    {
        gameOverTxt.text = "Game Over";
        gameRunning = false;
        canScore = false;
        shoot.canShoot = false;
        StartCoroutine(GameEndWait());
    }

    void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    void Pause()
    {
        Time.timeScale = 0f;
        canScore = false;
        savedSpeed = rollScr.speed;
        rollScr.speed = 0f;
        rollScr.canAdd = false;
        pause.enabled = false;
        pause.GetComponent<Image>().enabled = false;
        play.enabled = true;
        play.GetComponent<Image>().enabled = true;
    }


    void Play()
    {
        Time.timeScale = 1f;
        canScore = true;
        rollScr.speed = savedSpeed;
        rollScr.canAdd = true;
        pause.enabled = true;
        pause.GetComponent<Image>().enabled = true;
        play.enabled = false;
        play.GetComponent<Image>().enabled = false;
    }

    IEnumerator GameEndWait()
    {
        yield return new WaitForSeconds(5f);
        restart.enabled = true;
        restart.GetComponent<Image>().enabled = true;
    }

    IEnumerator StartCooldown()
    {
        canSpawn = false;
        yield return new WaitForSeconds(cooldown);
        canSpawn = true;
    }
}

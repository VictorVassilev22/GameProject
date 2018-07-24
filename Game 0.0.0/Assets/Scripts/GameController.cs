using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class GameController : MonoBehaviour {

    public GameObject hazard;
    public Vector2 spawnValues;


    public bool gameRunning = true;
    public bool canSpawn = true;
    public bool canScore = true;
    public bool canSpeed = true;
    public bool canShortCooldown = true;

    public float cooldown = 3.0f;
    public float score = 0.0f;
    public float highScore = 0.0f;
    public int enemiesPassed = 0;
    public float savedSpeed;

    public static float moveSpeed = 2.0f;
    public float enemySpd = moveSpeed;
    private float resetSpd = moveSpeed;

    public Text showScore;
    public Text showHighScore;
    public Text gameOverTxt;

    private Vector2 lastPos = new Vector2();
    private ShootMissle shoot;
    private RollingScript rollScr;
    private PauseMenuScript pmScr;

    public GameObject reset;

    private void Start()
    {
        showHighScore.text = PlayerPrefs.GetInt("Text(3)", 0).ToString();
        shoot = GameObject.Find("Player").GetComponent<ShootMissle>();
        pmScr = GameObject.Find("PauseMenu").GetComponent<PauseMenuScript>();
        rollScr = GameObject.Find("Street").GetComponent<RollingScript>();
    }

    void Update()
    {
        if(gameRunning&&canSpawn)
        SpawnWaves();

        if(canScore)
        score += 0.1f;

        if(cooldown>1.0f)
       if(canShortCooldown) cooldown-=0.0004f;

        int intScore = (int)score;
        showScore.text = (intScore).ToString();
        if (score> PlayerPrefs.GetInt("Text(3)", 0))
        {
            PlayerPrefs.SetInt("Text(3)", intScore);
            showHighScore.text = intScore.ToString();
        }

        if(canSpeed)moveSpeed += 0.00045f;
        enemySpd = moveSpeed;

        if (HealthBarScript.health <= 0)
        {
            EndGame();
        }
    }

    void SpawnWaves()
    {
        for (int i = 0; i <=5; i++)
        {
            Vector2 spawnPosition = new Vector2(UnityEngine.Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y);
            Quaternion spawnRotation = Quaternion.identity;

            if (lastPos.x - spawnPosition.x >= 2.7f || i == 0)
            {
                Instantiate(hazard, spawnPosition, spawnRotation);
                lastPos = spawnPosition;
            }
        }
        StartCoroutine(StartCooldown());
    }

    void EndGame()
    {
        gameOverTxt.text = "Game Over";
        gameRunning = false;
        canScore = false;
        shoot.canShoot = false;
        rollScr.canAdd = false;
        pmScr.pause.enabled = false;
        StartCoroutine(GameEndWait());
    }

    public void resetMoveSpeed()
    {
        moveSpeed = resetSpd;
    }

    IEnumerator GameEndWait()
    {
        yield return new WaitForSeconds(7.5f);
        Time.timeScale = 0f;
        rollScr.speed = 0f;
        pmScr.restart.enabled = true;
        pmScr.restart.GetComponent<Image>().enabled = true;
        reset.SetActive(true);
    }

    IEnumerator StartCooldown()
    {
        canSpawn = false;
        yield return new WaitForSeconds(cooldown);
        canSpawn = true;
    }
}

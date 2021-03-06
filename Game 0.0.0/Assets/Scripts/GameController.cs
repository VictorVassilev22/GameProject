﻿using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

    public GameObject hazard;
    public Vector2 spawnValues;


    public bool gameRunning = true;
    public bool canSpawn = true;
    public bool canScore = true;
    public bool canSpeed = true;
    public bool canShortCooldown = true;
    public static bool hasPlayed = false;

    public float cooldown = 3.0f;
    public float score = 0.0f;
    public float highScore = 0.0f;
    public int enemiesPassed = 0;
    public float savedSpeed;

    public static float moveSpeed = 1.0f;
    public static float enemySpd = moveSpeed;
    private float resetSpd = moveSpeed;

    public GameObject showScore;
    public GameObject showHighScore;
    public GameObject coinCounter;
    public GameObject healthText;
    public GameObject manaText;



    private Vector2 lastPos = new Vector2();
    private ShootMissle shoot;
    private AudioSource music;
    public GameObject reset;
    public GameObject deathMenu;

    private void Start()
    {
        hasPlayed = true;
        showHighScore.GetComponent<TextMesh>().text = PlayerPrefs.GetInt("Text(3)", 0).ToString();
        shoot = GameObject.Find("Player").GetComponent<ShootMissle>();
        //pmScr = GameObject.Find("PauseMenu").GetComponent<PauseMenuScript>();
        music = GameObject.Find("Music").GetComponent<AudioSource>();
        // pauseMenu = GameObject.Find("PauseMenu");
        coinCounter.GetComponent<TextMesh>().text = CoinScript.coinCount.ToString();
        ShowBarTexts();
        CoinScript.coinCount = 0;
    }

    void Update()
    {
        if(gameRunning&&canSpawn)
        {
            SpawnWaves();
        }
            

        if(canScore)
            score += 0.1f;

        //if(cooldown>1.0f)
       //if(canShortCooldown) cooldown-=0.0004f;

        int intScore = (int)score;
        showScore.GetComponent<TextMesh>().text = (intScore).ToString();
        ShowBarTexts();

        if (score> PlayerPrefs.GetInt("Text(3)", 0))
        {
            PlayerPrefs.SetInt("Text(3)", intScore);
            showHighScore.GetComponent<TextMesh>().text = intScore.ToString();
        }

        coinCounter.GetComponent<TextMesh>().text = CoinScript.coinCount.ToString();


        enemySpd = moveSpeed;

        if (HealthBarScript.health <= 0)
        {
            HealthBarScript.shieldPoints = 0;
            EndGame();
        }
    }
    void ShowBarTexts()
    {
        healthText.GetComponent<TextMesh>().text = HealthBarScript.health.ToString() + " / " + HealthBarScript.maxHealth;
        manaText.GetComponent<TextMesh>().text = (ManaBarScript.mana - 1).ToString() + " / " + (ManaBarScript.maxMana - 1);
    }
    void SpawnWaves()
    {
        for (int i = 0; i <= 5; i++)
        {
            Vector2 spawnPosition = new Vector2(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y);
            Quaternion spawnRotation = Quaternion.identity;

            if (lastPos.x - spawnPosition.x >= 2.7f || i == 0)
            {
                Instantiate(hazard, spawnPosition, spawnRotation);
                lastPos = spawnPosition;
                //Debug.Log(pauseMenu);
            }
            
            StartCoroutine(StartCooldown());
        }
    }
    public static void ShowPowerUpAnimation(GameObject animation, Transform transform)
    {
        var anim = Instantiate(animation, new Vector2(transform.position.x-1f, transform.position.y+0.3f), Quaternion.identity, transform);
    }

    public static void ShowTextEffect(float amount, GameObject textEffect, Transform transform)
    {
        var text = Instantiate(textEffect, (Vector2)transform.position, Quaternion.identity, transform);
        if (amount >= 0)
            text.GetComponent<TextMesh>().text = "+" + amount.ToString();
        else
            text.GetComponent<TextMesh>().text = amount.ToString();
    }

    void EndGame()
    {
        canScore = false;
        //canSpawn = false;
        gameRunning = false;
        //ShootMissle.canShoot = false;
        PowerUpActivation.NullOrderedBarsList();
        PlayerPrefs.SetInt("Loot", CoinScript.coinCount);
        StartCoroutine(GameEndWait());
    }

    public void resetMoveSpeed()
    {
        moveSpeed = resetSpd;
    }

    IEnumerator GameEndWait()
    {
        music.Stop();
        yield return new WaitForSeconds(1.5f);
            deathMenu.SetActive(true);           
    }

    IEnumerator StartCooldown()
    {
        canSpawn = false;
        yield return new WaitForSeconds(cooldown);
        if(gameRunning)
            canSpawn = true;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

    public GameObject hazard;
    public Vector2 spawnValues;
    private bool canSpawn = true;
    public float cooldown = 1.0f;
    public float score = 0.0f;
    public float highScore = 0.0f;
    public Text showScore;
    public Text showHighScore;

    private void Start()
    {
        showHighScore.text = PlayerPrefs.GetInt("Text(3)", 0).ToString();
    }
    void Update()
    {
        if(canSpawn)
        SpawnWaves();

        score += 0.1f;
        cooldown-= score / 10000000f;
        int intScore = (int)score;
        showScore.text = (intScore).ToString();
        if (score> PlayerPrefs.GetInt("Text(3)", 0))
        {
            PlayerPrefs.SetInt("Text(3)", intScore);
            showHighScore.text = intScore.ToString();
        }
    }

    void SpawnWaves()
    {
        Vector2 spawnPosition = new Vector2(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y);
        Quaternion spawnRotation = Quaternion.identity;
        Instantiate(hazard, spawnPosition, spawnRotation);
        StartCoroutine(StartCooldown());
    }

    IEnumerator StartCooldown()
    {
        canSpawn = false;
        yield return new WaitForSeconds(cooldown);
        canSpawn = true;
    }
}

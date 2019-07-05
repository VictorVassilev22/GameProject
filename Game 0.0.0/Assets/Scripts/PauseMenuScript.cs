using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenuScript : MonoBehaviour {
    private GameController ctrlScript;
    private RollingScript rollScr;
    private LongPressSpell spellButton;

    // Use this for initialization
    void Start () {
        ctrlScript = GameObject.Find("GameController").GetComponent<GameController>();
        rollScr = GameObject.Find("Street").GetComponent<RollingScript>();
       spellButton= GameObject.Find("SpellButton").GetComponent<LongPressSpell>();
    }
  public void RestartGame()
    {  
        spellButton.SetEnabled();
        HealthBarScript.shieldPoints = 0;
        HealthBarScript.canBreakShield = false;
        GameController.gameRunning = true;
        ctrlScript.canSpawn = true;
        CoinScript.coinCount = 0;
        ctrlScript.cooldown = 3.0f;
        ctrlScript.savedSpeed = 0.5f;
        rollScr.speed = 0.5f;
        rollScr.canAdd = true;
        Time.timeScale = 1f;
        PowerUpActivation.NullOrderedBarsList();
        ctrlScript.resetMoveSpeed();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        ShootMissle.canShoot = true;
    }
  public void Pause()
    {
        Time.timeScale = 0f;
        ShootMissle.canShoot = false;
        ctrlScript.canScore = false;
        ctrlScript.savedSpeed = rollScr.speed;
        rollScr.speed = 0f;
        rollScr.canAdd = false;
        ctrlScript.canShortCooldown = false;
        ctrlScript.canSpeed = false;
        //Debug.Log(ShootMissle.canShoot);
        //play.GetComponent<Image>().enabled = true;
       // restart.GetComponent<Image>().enabled = true;
    }
  public void Play()
    {
        Time.timeScale = 1f;
        ctrlScript.canScore = true;
        rollScr.speed = ctrlScript.savedSpeed;
        rollScr.canAdd = true;
        ctrlScript.canShortCooldown = true;
        ctrlScript.canSpeed = true;
        ShootMissle.canShoot = true;
        Debug.Log(ShootMissle.canShoot);
    }
}

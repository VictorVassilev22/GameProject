using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenuScript : MonoBehaviour {
    public static GameController ctrlScript;
    private LongPressSpell spellButton;

    // Use this for initialization
    void Start () {
        ctrlScript = GameObject.Find("GameController").GetComponent<GameController>();
       spellButton= GameObject.Find("SpellButton").GetComponent<LongPressSpell>();
    }
  public void RestartGame()
    {  
        PowerUpActivation.NullOrderedBarsList(); // null powerup cooldown placers
        ctrlScript.resetMoveSpeed();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        ShootMissle.canShoot = true;
        //spellButton.SetEnabled();
        HealthBarScript.shieldPoints = 0;
        HealthBarScript.canBreakShield = false;
        CoinScript.coinCount = 0;
        ctrlScript.cooldown = 3.0f;
        ctrlScript.savedSpeed = 0.5f;
        Time.timeScale = 1f;
        ctrlScript.canSpawn = true;
        ctrlScript.gameRunning = true;
    }
  public void Pause()
    {
        Time.timeScale = 0f;
       // ShootMissle.canShoot = false;
        ctrlScript.canScore = false;
        ctrlScript.canShortCooldown = false;
        ctrlScript.canSpeed = false;
        ctrlScript.canSpawn = false;
        //Debug.Log(ShootMissle.canShoot);
        //play.GetComponent<Image>().enabled = true;
       // restart.GetComponent<Image>().enabled = true;
    }
  public void Play()
    {
        Time.timeScale = 1f;
        ctrlScript.canScore = true;
        ctrlScript.canShortCooldown = true;
        ctrlScript.canSpeed = true;
        ShootMissle.canShoot = true;
        Debug.Log(ShootMissle.canShoot);
        ctrlScript.gameRunning = true;
    }
}

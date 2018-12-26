using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenuScript : MonoBehaviour {
    private GameController ctrlScript;
    private RollingScript rollScr;
    public Button play;
    public Button restart;
    public Button pause;
    private LongPressSpell spellButton;

    // Use this for initialization
    void Start () {
        ctrlScript = GameObject.Find("GameController").GetComponent<GameController>();
        rollScr = GameObject.Find("Street").GetComponent<RollingScript>();
        play = GameObject.Find("Play").GetComponent<Button>();
        restart = GameObject.Find("Restart").GetComponent<Button>();
        pause = GameObject.Find("Pause").GetComponent<Button>();
       spellButton= GameObject.Find("SpellButton").GetComponent<LongPressSpell>();
    }
  public void RestartGame()
    {
        spellButton.SetEnabled();
        ShootMissle.canShoot = true;
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
    }
  public void Pause()
    {
        Time.timeScale = 0f;
        ctrlScript.canScore = false;
        ctrlScript.savedSpeed = rollScr.speed;
        rollScr.speed = 0f;
        rollScr.canAdd = false;
        ctrlScript.canShortCooldown = false;
        ctrlScript.canSpeed = false;
        play.GetComponent<Image>().enabled = true;
        restart.GetComponent<Image>().enabled = true;
    }
  public void Play()
    {
        Time.timeScale = 1f;
        ctrlScript.canScore = true;
        rollScr.speed = ctrlScript.savedSpeed;
        rollScr.canAdd = true;
        ctrlScript.canShortCooldown = true;
        ctrlScript.canSpeed = true;
        play.GetComponent<Image>().enabled = false;
        restart.GetComponent<Image>().enabled = false;
    }
}

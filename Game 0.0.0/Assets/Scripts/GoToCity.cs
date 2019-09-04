using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GoToCity : MonoBehaviour
{

    private Animator animator;
    private GameController gamectrl;
    // Start is called before the first frame update
    void Start()
    {
        animator = GameObject.Find("SceneTransition").GetComponent<Animator>();
        gamectrl = GameObject.Find("GameController").GetComponent<GameController>();
    }

    // Update is called once per frame
    void Update()
    {

    }

 
    public void goToCity()
    {
        if (gamectrl.gameRunning)
        {
            PlayerPrefs.SetInt("Loot", 0);
        }
        Time.timeScale = 1f;
        fadeToScene(0);
        PlayerFadeOut.canFade = false;
    }
    public void fadeToScene(int sceneIndex)
    {
        ChangeScene.sceneToLoad = sceneIndex;
        animator.SetTrigger("FadeBlack");
    }
}
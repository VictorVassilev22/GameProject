using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GoOnQuestScr : MonoBehaviour
{

    private Animator animator;
    private GameObject player;


    // Start is called before the first frame update
    void Start()
    {
        animator = GameObject.Find("SceneTransition").GetComponent<Animator>();
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.name == "Player")
        {
            PlayerFadeOut.canFade = true;
            Debug.Log("Here");
            this.GetComponent<Rigidbody2D>().simulated = false;
            player.GetComponent<TownAccelerator>().speed = 1;
            fadeToScene(1);
        }
    }

    public void fadeToScene(int sceneIndex)
    {
       ChangeScene.sceneToLoad = sceneIndex;
        animator.SetTrigger("FadeBlack");
    }
}

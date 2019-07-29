using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GoToCity : MonoBehaviour
{

    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GameObject.Find("SceneTransition").GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

    }

 
    public void goToCity()
    {
        fadeToScene(0);
    }
    public void fadeToScene(int sceneIndex)
    {
        ChangeScene.sceneToLoad = sceneIndex;
        animator.SetTrigger("FadeBlack");
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrierScript : MonoBehaviour {
    private Animator animation;

    public void Activate()
    { 
       this.gameObject.SetActive(true);
    }

    void Start () {
        animation = GetComponent<Animator>();
    }
	
	void Update () {
        if (!PowerUpActivation.powerupEnablers[1])
        {
            animation.SetTrigger("disappearTrigger");
            StartCoroutine(DestroyBarrier());
        }
    }

    IEnumerator DestroyBarrier()
    {
        yield return new WaitForSeconds(2);
        this.gameObject.SetActive(false);
    }
}

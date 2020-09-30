using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missle : MonoBehaviour
{

    [SerializeField]
    float speed = 5f;

    Animator missleAnimator;
    bool isFinished = false;
    // Start is called before the first frame update
    void Start()
    {
        missleAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        AnimatorStateInfo info = missleAnimator.GetCurrentAnimatorStateInfo(0);
        if (info.IsName("Missle_Charging"))
        {
            if (info.normalizedTime>1 && !isFinished)
            {
                isFinished = true;
                Vector2 directionUp = new Vector2(0, 1);
                GetComponent<Rigidbody2D>().AddForce(speed * directionUp, ForceMode2D.Impulse);              
            }
        }
    }
}

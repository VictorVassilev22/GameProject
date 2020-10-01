using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missle : MonoBehaviour
{

    [SerializeField]
    float speed = 5f;

    Animator missleAnimator;
    CircleCollider2D collider;

    bool isFinished = false;
    // Start is called before the first frame update
    void Start()
    {
        missleAnimator = GetComponent<Animator>();
        collider = GetComponent<CircleCollider2D>();
        collider.enabled = false;
        
    }

    // Update is called once per frame
    void Update()
    {
        AnimatorStateInfo info = missleAnimator.GetCurrentAnimatorStateInfo(0);
        if (info.IsName("Missle_Charging")) //if charging animation is playing
        {
            if (info.normalizedTime>1 && !isFinished) //if time playing animation is up 
            {
                isFinished = true; //set animation as finished
                collider.enabled = true;
                Vector2 directionUp = new Vector2(0, 1);
                GetComponent<Rigidbody2D>().AddForce(speed * directionUp, ForceMode2D.Impulse); //add force to move missle upwards          
            }
        }
    }
}

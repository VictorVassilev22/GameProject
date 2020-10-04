using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missle : MonoBehaviour
{

    [SerializeField]
    protected float speed = 5f;

    protected Vector2 impulseDirection;

    protected Animator missleAnimator;
    protected Collider2D missleCollider;

    protected string animationName;

    [SerializeField]
    protected bool hasChargingAnimation = true;

    protected bool isAnimFinished = false;
    protected bool hasLaunched = false;
    // Start is called before the first frame update
    virtual protected void Start()
    {
        missleAnimator = GetComponent<Animator>();
        missleCollider = GetComponent<Collider2D>();
        missleCollider.enabled = false;

        //Setting the animation name
        animationName = "Missle_Charging";

        //Setting direction UP
        SetDirection(0, 1);

    }

    // Update is called once per frame
    virtual protected void Update()
    {
        if ((!hasChargingAnimation || CheckForAnimationEnd(animationName)) && !hasLaunched)
        {
            Launch(speed, impulseDirection);
            hasLaunched = true;
        }
    }
    /// <summary>
    /// Usually a charging animation is played. This method checks if the animation has finished or is still playing
    /// </summary>
    /// <param name="anim_name"> The name of the animation as created in the Unity Editor </param>
    /// <returns> if animation is still playing (true) or not (false) </returns>
    protected bool CheckForAnimationEnd(string anim_name)
    {

        AnimatorStateInfo info = missleAnimator.GetCurrentAnimatorStateInfo(0);
        if (info.IsName("Missle_Charging")) //if charging animation is playing
        {
            if (info.normalizedTime > 1 && !isAnimFinished) //if time playing animation is up 
            {
                isAnimFinished = true; //set animation as finished    
                return true;
            }
        }

        return false;
    }

    /// <summary>
    /// Adds force in a particular direction to the missle to launch it. More speed -> more force is applied.
    /// </summary>
    /// <param name="speed"> Speed of the missle</param>
    /// <param name="direction"> Direction to be launched</param>
    protected void Launch(float speed, Vector2 direction)
    {
        missleCollider.enabled = true;
        GetComponent<Rigidbody2D>().AddForce(speed * direction, ForceMode2D.Impulse); //add force to move missle upwards
    }

    /// <summary>
    /// Sets direction in x and y coordinates
    /// </summary>
    /// <param name="x"></param>
    /// <param name="y"></param>
    protected void SetDirection(float x, float y)
    {
        impulseDirection.x = x;
        impulseDirection.y = y;
    }

}

  

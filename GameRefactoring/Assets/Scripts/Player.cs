using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : RangedCombatEntity, IMoveable, IDamagable, IKillable
{
    [SerializeField]
    float moveSpeed = 800f;

    bool mouseClicked = false;

    float horizontalTilt;

    // Update is called once per frame
    protected override void Update()
    {

        base.Update();
        moveListener(); // arrows (a and d), tilt
        
    }

    public void moveListener()
    {
        horizontalTilt = Input.GetAxis("Horizontal");


#if UNITY_ANDROID
        horiz = Input.acceleration.x;
#endif

        Move();
    }


    protected override void attackListener()
    {
        mouseClicked = Input.GetAxis("Attack") > 0 && !timer.IsRunning;

#if UNITY_ANDROID
        mouseClicked = Input.touches.Length > 0 && !timer.IsRunning;
#endif

        playerAnimator.SetBool("Attack", mouseClicked);


        if (mouseClicked)
        {
            if (!hasAttacked)
            {
                attack();
            }
        }
        else
        {
            hasAttacked = false;
        }
    }

    public void Move()
    {
        rbody.velocity = new Vector2(horizontalTilt * moveSpeed * Time.deltaTime, 0);
    }

    public void takeDamage(float damage)
    {

    }

    public void killListener()
    {
        //if health is <=0 && !isAlive
        isAlive = false;
        canAttack = false;
        playDeathAnimation();
        //if death animation has finished
        kill();
    }

    public void kill()
    {
        //if death animation has finished
        Destroy(gameObject);
    }

    public void playDeathAnimation()
    {
        //TODO:
        //1. stop and reset timer
        //2. set timer duration to that of death animation
        //3. play animation
        //4. run timer
        //5. in killListener see when death animation has finished, then kill
    }
}

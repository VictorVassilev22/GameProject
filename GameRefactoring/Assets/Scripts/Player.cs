using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : CombatEntity, IMoveable
{
    const float MinOffsetFromPlayer = 0.3f;

    [SerializeField]
    float moveSpeed = 800f;

    [SerializeField]
    protected float attackCooldown = 1f;

    [SerializeField]
    float missleOffsetFromPlayer = 0f;

    [SerializeField]
    GameObject projectilePrefab;

    Collider2D projectileCollider;


    bool mouseClicked = false;
    bool hasAttacked = false;

    float horizontalTilt;

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        projectileCollider = projectilePrefab.GetComponent<Collider2D>();
        timer.IsFixed = true;
        extractProjectileLoadTime();
        timer.Duration = attackCooldown;
    }

    // Update is called once per frame
    void Update()
    {
   
        attackListener(); // left mouse button, tap
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

    protected override void attack()
    {
        GameObject missle;
        Vector3 position;
        float yOffset;

        yOffset = entityCollider.bounds.extents.y + projectileCollider.bounds.extents.y + missleOffsetFromPlayer + MinOffsetFromPlayer;
        position = new Vector3(transform.position.x, transform.position.y + yOffset, transform.position.z);

        missle = Instantiate<GameObject>(projectilePrefab, position, Quaternion.identity);
        missle.transform.parent = gameObject.transform;
        hasAttacked = true;
        timer.Restart();
    }

    void extractProjectileLoadTime()
    {
        GameObject missle = Instantiate<GameObject>(projectilePrefab, new Vector3(0, 0, 0), Quaternion.identity);

        AnimatedProjectile aProj = missle.GetComponent<AnimatedProjectile>();

        if (aProj != null)
            attackCooldown += aProj.AnimationLength;

        Destroy(missle);
    }
}

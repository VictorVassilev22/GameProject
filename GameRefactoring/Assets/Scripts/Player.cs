using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    const float MinAttackCooldown = 0.7f;
    const float MinOffsetFromPlayer = 0.3f;

    [SerializeField]
    float attackCooldown = 1f;

    [SerializeField]
    float moveSpeed = 800f;

    [SerializeField]
    float missleOffsetFromPlayer = 0f;

    [SerializeField]
    GameObject misslePrefab;


    Rigidbody2D rbody;
    BoxCollider2D playerCollider;
    CircleCollider2D missleCollider;
    Animator playerAnimator;
    Timer timer;

    bool mouseClicked = false;
    bool hasAttacked = false;

    float horizontalTilt;


    // Start is called before the first frame update
    void Start()
    {
        rbody = GetComponent<Rigidbody2D>();
        playerCollider = GetComponent<BoxCollider2D>();
        missleCollider = misslePrefab.GetComponent<CircleCollider2D>();
        playerAnimator = GetComponent<Animator>();
        timer = gameObject.AddComponent<Timer>();

        timer.IsFixed = true;

        if (attackCooldown < MinAttackCooldown)
        {
            attackCooldown = MinAttackCooldown;
        }

        timer.Duration = attackCooldown;      
    }

    // Update is called once per frame
    void Update()
    {
        AttackListener(); // left mouse button, tap
        MoveListener(); // arrows (a and d), tilt
        
    }

    void MoveListener()
    {
        horizontalTilt = Input.GetAxis("Horizontal");


#if UNITY_ANDROID
        horiz = Input.acceleration.x;
#endif

        Move();
    }

    void AttackListener()
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
                Attack();
            }
        }
        else
        {
            hasAttacked = false;
        }
    }

    void Move()
    {
        rbody.velocity = new Vector2(horizontalTilt * moveSpeed * Time.deltaTime, 0);
    }

    void Attack()
    {
        GameObject missle;
        Vector3 position;
        float yOffset;

        yOffset = playerCollider.bounds.extents.y + missleCollider.bounds.extents.y + missleOffsetFromPlayer + MinOffsetFromPlayer;
        position = new Vector3(transform.position.x, transform.position.y + yOffset, transform.position.z);

        missle = Instantiate<GameObject>(misslePrefab, position, Quaternion.identity);
        missle.transform.parent = gameObject.transform;
        hasAttacked = true;
        timer.Restart();
    }
}

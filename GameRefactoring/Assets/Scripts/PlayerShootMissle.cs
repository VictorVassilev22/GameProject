using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShootMissle : MonoBehaviour
{
    const float MinAttackCooldown = 0.7f;
    const float MinOffset = 0.3f;

    [SerializeField]
    float missleOffsetFromPlayer = 0f;

    [SerializeField]
    float attackCooldown = 1f;

    [SerializeField]
    GameObject misslePrefab;

    Timer timer;
    Animator playerAnimator;
    GameObject missle;
    BoxCollider2D playerCollider;
    Vector3 position;

    bool mouseClicked = false;
    bool hasFired = false;

    // Start is called before the first frame update
    void Start()
    {
        playerAnimator = GetComponent<Animator>();
        playerCollider = GetComponent<BoxCollider2D>();
        timer = gameObject.AddComponent<Timer>();
        timer.IsFixed = true;
        timer.FixedTime = attackCooldown;

        if (attackCooldown < MinAttackCooldown)
        {
            attackCooldown = MinAttackCooldown;
        }

        if(missleOffsetFromPlayer < MinOffset)
        {
            missleOffsetFromPlayer = MinOffset;
        }
    }

    // Update is called once per frame
    void Update()
    {
        mouseClicked = Input.GetAxis("Attack") > 0 && !timer.IsRunning;
        playerAnimator.SetBool("Attack", mouseClicked);

        float yOffset = playerCollider.bounds.extents.y;
        position = new Vector3(transform.position.x, transform.position.y + yOffset + missleOffsetFromPlayer, transform.position.z);

        if (mouseClicked)
        {
            if (!hasFired && !timer.IsRunning)
            {            
                missle = Instantiate<GameObject>(misslePrefab, position, Quaternion.identity);               
                hasFired = true;
                timer.Restart();
            }
        }
        else
        {
            hasFired = false;
        }

        if (GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("Player_ChargeMissle"))
        {
            missle.transform.position = position;
        }
    }
}

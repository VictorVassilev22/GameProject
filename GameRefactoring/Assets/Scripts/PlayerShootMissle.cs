using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShootMissle : MonoBehaviour
{

    [SerializeField]
    float missleOffsetFromPlayer = 0f;

    [SerializeField]
    float attackCooldown = 1f;

    [SerializeField]
    GameObject misslePrefab;


    Timer timer;
    Animator playerAnimator;
    bool mouseClicked = false;
    bool hasFired = false;

    // Start is called before the first frame update
    void Start()
    {
        playerAnimator = GetComponent<Animator>();
        timer = gameObject.AddComponent<Timer>();
        timer.IsFixed = true;
        timer.FixedTime = attackCooldown;
    }

    // Update is called once per frame
    void Update()
    {
        mouseClicked = Input.GetAxis("Attack") > 0 && !timer.IsRunning;
        playerAnimator.SetBool("Attack", mouseClicked);

        if (mouseClicked)
        {
            if (!hasFired && !timer.IsRunning)
            {
                float yOffset = GetComponent<BoxCollider2D>().bounds.extents.y;
                Vector3 position = new Vector3(transform.position.x, transform.position.y + yOffset + missleOffsetFromPlayer, transform.position.z);               
                GameObject missle = Instantiate<GameObject>(misslePrefab, position, Quaternion.identity);               
                hasFired = true;
                timer.Restart();
            }
        }
        else
        {
            hasFired = false;
        }

    }
}

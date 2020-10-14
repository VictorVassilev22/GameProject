using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CombatEntity : MonoBehaviour
{
    [SerializeField]
    protected float attackPoints = 1f;

    [SerializeField]
    protected float attackCooldown = 1f;

   protected Rigidbody2D rbody;
   protected BoxCollider2D playerCollider;
   protected Collider2D missleCollider;
   protected Animator playerAnimator;
   protected Timer timer;

    // Start is called before the first frame update
    protected void Start()
    {
        rbody = GetComponent<Rigidbody2D>();
        playerCollider = GetComponent<BoxCollider2D>();;
        playerAnimator = GetComponent<Animator>();
        timer = gameObject.AddComponent<Timer>();
    }

    protected abstract void attackListener();
    protected abstract void attack();
}

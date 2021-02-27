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
    protected Collider2D entityCollider;
    protected Animator playerAnimator;
    protected Timer timer;
    protected bool canAttack = true;
    protected bool isAlive = true;

    // Start is called before the first frame update
    protected virtual void Start()
    {
        rbody = GetComponent<Rigidbody2D>();
        entityCollider = GetComponent<Collider2D>();
        playerAnimator = GetComponent<Animator>();
        timer = gameObject.AddComponent<Timer>();
    }

    protected abstract void attackListener();
    protected abstract void attack();
}

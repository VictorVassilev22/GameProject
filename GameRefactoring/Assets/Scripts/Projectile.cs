using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Projectile : MonoBehaviour
{

    [SerializeField]
    protected float speed = 5f;

    [SerializeField]
    protected Vector2 impulseDirection = new Vector2(0,1);

    protected Collider2D projectileCollider;
    protected bool hasLaunched = false;

    // Start is called before the first frame update
    protected virtual void Start()
    {
        GetComponent<Rigidbody2D>().gravityScale = 0.0f;
        projectileCollider = GetComponent<Collider2D>();
        impulseDirection = impulseDirection.normalized;
    }

    protected void Launch(float speed, Vector2 direction)
    {
        projectileCollider.enabled = true;
        GetComponent<Rigidbody2D>().AddForce(speed * direction, ForceMode2D.Impulse); //add force to launch projectile
    }

    protected void SetDirection(float x, float y)
    {
        impulseDirection.x = x;
        impulseDirection.y = y;
    }
}

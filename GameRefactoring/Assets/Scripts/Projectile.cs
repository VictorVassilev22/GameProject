using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
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
        projectileCollider = GetComponent<Collider2D>();
        projectileCollider.enabled = false;
        impulseDirection = impulseDirection.normalized;
        Launch(speed, impulseDirection);
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

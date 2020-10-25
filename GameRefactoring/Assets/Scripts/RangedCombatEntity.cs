using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class RangedCombatEntity : CombatEntity
{

    protected const float MinOffsetFromObject = 0.3f;

    [SerializeField]
    protected float missleOffsetFromObject = 0f;

    [SerializeField]
    protected GameObject projectilePrefab;

    protected Collider2D projectileCollider;
    protected bool hasAttacked = false;

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
    protected virtual void Update()
    {
        if(canAttack)
            attackListener(); // left mouse button, tap

    }

    protected override void attack()
    {
        GameObject missle;
        Vector3 position;
        float yOffset;

        yOffset = entityCollider.bounds.extents.y + projectileCollider.bounds.extents.y + missleOffsetFromObject + MinOffsetFromObject;
        position = new Vector3(transform.position.x, transform.position.y + yOffset, transform.position.z);

        missle = Instantiate<GameObject>(projectilePrefab, position, Quaternion.identity);
        missle.transform.parent = gameObject.transform;
        hasAttacked = true;
        timer.Restart();
    }

    void extractProjectileLoadTime()
    {
        GameObject projectile = Instantiate<GameObject>(projectilePrefab, new Vector3(0, 0, 0), Quaternion.identity);

        //TODO: Change this to work on any projectile
        Projectile aProj = projectile.GetComponent<Projectile>();

        
        if(aProj is ChargingProjectile)
        {
            if (aProj != null)
                attackCooldown += (aProj as ChargingProjectile).ChargingLength;
        }

        Destroy(projectile);
    }
}

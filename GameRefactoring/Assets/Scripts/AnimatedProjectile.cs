using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatedProjectile : Projectile
{
    protected Animator projectileAnimator;

    [SerializeField]
    protected string chargingAnimationName;

    [SerializeField]
    protected bool hasChargingAnimation = true;

    protected bool isAnimFinished = false;
    protected float animLength;

    public float AnimationLength
    {
        get { return animLength; }
    }

    private void Awake()
    {
        projectileAnimator = GetComponent<Animator>();
        animLength = projectileAnimator.runtimeAnimatorController.animationClips[0].length;
    }

    protected override void Start()
    {
        projectileCollider = GetComponent<Collider2D>();
        projectileCollider.enabled = false;
        impulseDirection = impulseDirection.normalized;
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        if ((!hasChargingAnimation || CheckForAnimationEnd(chargingAnimationName)) && !hasLaunched)
        {
            Launch(speed, impulseDirection);
            hasLaunched = true;
        }
        else if(!hasLaunched)
        {
           StayWithParent();
        }
    }

    protected bool CheckForAnimationEnd(string anim_name)
    {

        AnimatorStateInfo info = projectileAnimator.GetCurrentAnimatorStateInfo(0);
        if (info.IsName(anim_name)) //if charging animation is playing
        {
            if (info.normalizedTime > 1 && !isAnimFinished) //if time playing animation is up 
            {
                isAnimFinished = true; //set animation as finished    
                return true;
            }
        }

        return false;
    }

    protected void StayWithParent()
    {
        Transform parent = transform.parent;
        transform.position = new Vector3(parent.position.x, transform.position.y, transform.position.z);
    }
}

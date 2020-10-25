using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChargingProjectile : Projectile
{
    protected Animator projectileAnimator;

    [SerializeField]
    protected string chargingAnimationName;

    [SerializeField]
    protected bool hasChargingAnimation = true;

    protected bool isChargingFinished = false;
    protected float chargingLength;

    public float ChargingLength
    {
        get { return chargingLength; }
    }

    private void Awake()
    {
        projectileAnimator = GetComponent<Animator>();
        chargingLength = projectileAnimator.runtimeAnimatorController.animationClips[0].length;
    }

    protected override void Start()
    {
        base.Start();
        projectileCollider.enabled = false;
    }

    // Update is called once per frame
    protected void Update()
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
            if (info.normalizedTime > 1 && !isChargingFinished) //if time playing animation is up 
            {
                isChargingFinished = true; //set animation as finished    
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

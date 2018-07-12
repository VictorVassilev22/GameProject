using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootMissle : MonoBehaviour
{

    public GameObject missle;
    public Vector2 velocity;
    bool canShoot = true;
    public Vector2 offset = new Vector2(0.3f, 0.3f);
    public float cooldown = 0.5f;
    public float charge = 0.5f;
    private Animator animation;

    // Use this for initialization
    void Start()
    {
         animation = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
#if UNITY_ANDROID
          if (Input.touches.Length>0 && canShoot)
        {
            animation.SetTrigger("shootTrigger");
            StartCoroutine(Charge());
            StartCoroutine(ShootCooldown());
        }
#endif
        if (Input.GetMouseButtonDown(0) && canShoot)
        {
            animation.SetTrigger("shootTrigger");
            StartCoroutine(Charge());
            StartCoroutine(ShootCooldown());
        }
    }

    void Shoot()
    {
        GameObject firedMissle = (GameObject)Instantiate(missle, (Vector2)transform.position + offset * transform.localScale.y, Quaternion.identity);
        firedMissle.GetComponent<Rigidbody2D>().velocity = new Vector2(velocity.x, velocity.y * transform.localScale.y);

    }

    IEnumerator Charge()
    {
        yield return new WaitForSeconds(charge);
        Shoot();
    }

    IEnumerator ShootCooldown()
    {
        canShoot = false;
        yield return new WaitForSeconds(cooldown);
        canShoot = true;
    }
}

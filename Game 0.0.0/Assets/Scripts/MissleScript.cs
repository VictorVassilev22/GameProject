﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissleScript : MonoBehaviour {
    public float attack = 25.0f;
    public GameObject explosion;
    public Vector2 missleExplosionOffset = new Vector2(0.1f, -0.2f);

    [SerializeField]
    private bool timeDestroy;

    // Use this for initialization
    void Start () {
        if(timeDestroy) Destroy(this.gameObject, 1.0f);
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        EnemyCollisionHandler(collision);
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        EnemyCollisionHandler(col);
    }

    void EnemyCollisionHandler(Collider2D col)
    {
        if (col.gameObject.tag == "Enemy")
        {
            Destroy(this.gameObject);
            if(explosion) Instantiate(explosion, (Vector2)this.gameObject.transform.position + missleExplosionOffset * transform.localScale.y, this.gameObject.transform.rotation);
        }
    }

    void EnemyCollisionHandler(Collision2D col)
    {
        if (col.gameObject.tag == "Enemy")
        {
            Destroy(this.gameObject);
            if(explosion) Instantiate(explosion, (Vector2)this.gameObject.transform.position + (missleExplosionOffset-new Vector2(0f,0.3f)) * transform.localScale.y, this.gameObject.transform.rotation);
        }
    }


}

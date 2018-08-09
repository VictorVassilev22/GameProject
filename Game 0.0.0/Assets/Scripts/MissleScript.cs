using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissleScript : MonoBehaviour {
    public float attack = 25.0f;
    public GameObject explosion;
    public Vector2 missleExplosionOffset = new Vector2(0.1f, -0.2f);
    // Use this for initialization
    void Start () {
        Destroy(this.gameObject, 0.7f);
	}

    void OnTriggerEnter2D(Collider2D col)
    {
        Instantiate(explosion, (Vector2)this.gameObject.transform.position + missleExplosionOffset * transform.localScale.y, this.gameObject.transform.rotation);
    }

}

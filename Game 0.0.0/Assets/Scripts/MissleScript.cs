using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissleScript : MonoBehaviour {
    public float attack = 25.0f;
    public GameObject explosion;
    public Vector2 missleExplosionOffset = new Vector2(0.1f, -0.2f);
    public float destroyTime;

    [SerializeField]
    private bool timeDestroy;
    private GameObject Player;
    private Animator animation;

    // Use this for initialization
    void Start () {
        if(timeDestroy) Destroy(this.gameObject, destroyTime);
        Player = GameObject.Find("Player");
	}


    private void OnTriggerEnter2D(Collider2D col)
    {
        EnemyCollisionHandler(col);
    }

    void EnemyCollisionHandler(Collider2D col)
    {
        if (col.gameObject.tag == "Enemy")
        {
            if (this.gameObject.name != "Fireball_1(Clone)")
                Destroy(this.gameObject);
            else
            {
                LongPressSpell.pointerDown = false; //ako e golqm fireball pri dopir se izstrelva vednaga
            }
            if(explosion) Instantiate(explosion, (Vector2)this.gameObject.transform.position + missleExplosionOffset * transform.localScale.y, this.gameObject.transform.rotation);
        }
    }
}

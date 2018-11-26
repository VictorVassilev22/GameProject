using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombScript : MonoBehaviour {

    public GameObject ex_BombInstance;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag != "Boundary")
        {
            Destroy(this.gameObject);
            /*GameObject instance = */
            Instantiate(ex_BombInstance, (Vector2)(this.gameObject.transform.position), this.gameObject.transform.localRotation);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag != "Boundary")
        {
            Destroy(this.gameObject);
            /*GameObject instance = */
            Instantiate(ex_BombInstance, (Vector2)(this.gameObject.transform.position), this.gameObject.transform.localRotation);
        }
    }
}

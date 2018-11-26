using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombScript : MonoBehaviour {

    public GameObject ex_BombInstance;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag != "Boundary")
        {
            GameObject instance = Instantiate(ex_BombInstance, (Vector2)this.transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }
    }
}

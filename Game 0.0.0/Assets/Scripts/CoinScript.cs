using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinScript : MonoBehaviour {
	
	// Update is called once per frame
	void Update () {
        if (this.transform.position.y <= -13)
        {
            Destroy(this.gameObject);

        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.name == "Player")
        {
            Destroy(this.gameObject);
        }
    }
}

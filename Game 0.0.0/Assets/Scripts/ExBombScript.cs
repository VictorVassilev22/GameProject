using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExBombScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
        this.gameObject.GetComponent<CircleCollider2D>().enabled = false;
        StartCoroutine(Explode());
	}

    IEnumerator Explode()
    {
        yield return new WaitForSeconds(0.375f);
        this.gameObject.transform.localScale+=new Vector3(1f,1f,0);    
        yield return new WaitForSeconds(0.08f);
        this.gameObject.GetComponent<CircleCollider2D>().enabled = true;
        yield return new WaitForSeconds(0.07f);
        this.gameObject.GetComponent<CircleCollider2D>().enabled = false;

    }
}

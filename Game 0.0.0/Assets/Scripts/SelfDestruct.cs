using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestruct : MonoBehaviour {
    public float time = 0f;
	// Use this for initialization

	void Start () {
        Destroy(this.gameObject, time);
	}
	
}

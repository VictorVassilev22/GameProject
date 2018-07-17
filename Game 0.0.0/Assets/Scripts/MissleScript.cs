using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissleScript : MonoBehaviour {
    public float attack = 25.0f;
	// Use this for initialization
	void Start () {
        Destroy(this.gameObject, 0.7f);
	}

}

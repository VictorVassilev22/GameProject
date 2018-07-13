using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissleDestruct : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Destroy(this.gameObject, 0.7f);
	}

}

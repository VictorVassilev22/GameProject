using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Accelerator : MonoBehaviour {
	
	// Update is called once per frame
	void Update () {
        this.transform.Translate(Input.acceleration.x, 0, 0);
	}
}

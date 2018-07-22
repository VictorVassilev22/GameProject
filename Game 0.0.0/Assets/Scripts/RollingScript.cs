using UnityEngine;
using System.Collections;


public class RollingScript : MonoBehaviour {

    public float speed = 0.5f;
    public bool canAdd = true;

	// Update is called once per frame
	void Update () {

        Vector2 offset = new Vector2(0, Time.time * speed);
        GetComponent<Renderer>().material.mainTextureOffset = offset;
        if(canAdd) this.speed += 0.0001f;
	}
}

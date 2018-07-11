using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Accelerator : MonoBehaviour {
    public float speed = 250f;
    private Rigidbody rbody;
    private float horiz;


    private void Awake()
    {
        rbody = GetComponent<Rigidbody>();
    }
    // Update is called once per frame
    void Update () {
        horiz = Input.GetAxis("Horizontal");
#if UNITY_ANDROID
        horiz = Input.acceleration.x;
#endif

        this.rbody.velocity= new Vector2(horiz* speed*Time.deltaTime, 0);
	}
}

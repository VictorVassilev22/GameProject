using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestruct : MonoBehaviour {
    public float time = 0f;
    public bool hasTime;
    // Use this for initialization

    void Start () {
        if (hasTime)
            Destroy(this.gameObject, time);
	}

    private void Update()
    {

            if (this.transform.position.y <= -13)
            {
                Destroy(this.gameObject);
            }

    }
}


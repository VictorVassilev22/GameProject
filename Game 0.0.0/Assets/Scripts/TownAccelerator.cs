using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TownAccelerator : MonoBehaviour {
    public float speed = 800f;
    private float angle;
    private Touch touch;
    private Vector2 mousePosition;
    public Camera cam;
    private Vector2 direction;


    private bool isAndroid;
    private void Awake()
    {
        isAndroid = false;
        direction = new Vector2();
    }
    // Update is called once per frame
    void Update () {
       
       

        if (Input.GetMouseButton(0))
        {
            mousePosition = Input.mousePosition;           
        }
        else
        {
            mousePosition = this.transform.position;
        }


#if UNITY_ANDROID
        isAndroid=true;
        if (Input.touchCount > 0)
            touch = Input.GetTouch(0);
#endif
        if (!isAndroid)
        {
            if (Input.GetMouseButton(0) && Mathf.Abs(transform.position.x - mousePosition.x) >= 3 && Mathf.Abs(transform.position.y - mousePosition.y) >= 3)
            {
                 direction = new Vector2(cam.ScreenToWorldPoint(mousePosition).x - transform.position.x, cam.ScreenToWorldPoint(mousePosition).y - transform.position.y);
                transform.position = Vector2.MoveTowards(transform.position, cam.ScreenToWorldPoint(new Vector3(mousePosition.x, mousePosition.y, 0.0f)), speed * Time.deltaTime);
            }
        }           
        else
        {
            if (Input.touchCount > 0 && Mathf.Abs(transform.position.x-mousePosition.x)>=3 && Mathf.Abs(transform.position.y - mousePosition.y) >= 3)
            {
                direction = new Vector2(cam.ScreenToWorldPoint(touch.position).x - transform.position.x, cam.ScreenToWorldPoint(touch.position).y - transform.position.y);
                transform.position = Vector2.MoveTowards(transform.position, cam.ScreenToWorldPoint(new Vector3(touch.position.x, touch.position.y, 0.0f)), speed * Time.deltaTime);
            }             
        }

        
        transform.up = direction;
	}
}

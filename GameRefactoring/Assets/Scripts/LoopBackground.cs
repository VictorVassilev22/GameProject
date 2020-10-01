using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoopBackground : MonoBehaviour
{
    [SerializeField]
    int layersCount;

    public float speed;
    Vector2 startPos;  

    private void Start()
    {
        startPos = transform.position;
    }
    // Update is called once per frame
    void Update()
    {
        float newPos = Mathf.Repeat(Time.time * speed, layersCount*ScreenUtils.ScreenTop*2);
        transform.position = startPos + Vector2.down * newPos;
    }
}
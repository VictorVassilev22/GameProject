using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoopBackground : MonoBehaviour
{
    [SerializeField]
    int layersCount;

    public float speed;
    Vector2 startPos;

    // *to designers (if you read code)* if you notice any lag on looping the background experiment with this value
    // make it slight smaller or larger
    const float antiLagOffset = 0.155f;

    private void Start()
    {
        startPos = transform.position;
    }
    // Update is called once per frame
    void Update()
    {
        //calculating length of the background (in Y axis)
        float length = layersCount * ScreenUtils.ScreenTop * 2 - antiLagOffset;

        //repeats the length calculated above at certain speed
        float newPos = Mathf.Repeat(Time.time * speed, length);
        transform.position = startPos + Vector2.down * newPos;
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetBgLayer : MonoBehaviour
{
    [SerializeField]
    int backgroundLayer = 0;

    float offsetFromCenterY;

    // Start is called before the first frame update
    void Start()
    {
        Vector3 cameraPosition = Camera.main.transform.position;
        offsetFromCenterY = backgroundLayer * ScreenUtils.ScreenTop * 2;

        transform.position = new Vector3(cameraPosition.x, cameraPosition.y + offsetFromCenterY, -cameraPosition.z);
    }
}

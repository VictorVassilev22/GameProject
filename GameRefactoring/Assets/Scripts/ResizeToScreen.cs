using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResizeToScreen : MonoBehaviour
{
    [SerializeField]
    bool KeepAspectRatio;

    /// <summary>
    /// Start is called when the game begins
    /// </summary>
    void Start()
    {
        //getting hight and width for the current screen
        var worldSpaceWidth = ScreenUtils.ScreenRight * 2;
        var worldSpaceHeight = ScreenUtils.ScreenTop * 2;

        
        var spriteSize = gameObject.GetComponent<SpriteRenderer>().bounds.size;

        // calculating the scaling factor of the image
        var scaleFactorX = worldSpaceWidth / spriteSize.x;
        var scaleFactorY = worldSpaceHeight / spriteSize.y;

        // keeping the aspect ratio if needed
        if (KeepAspectRatio)
        {
            if (scaleFactorX > scaleFactorY)
            {
                scaleFactorY = scaleFactorX;
            }
            else
            {
                scaleFactorX = scaleFactorY;
            }
        }

        //changing the scale of the sprite to match current screen
        gameObject.transform.localScale = new Vector3(scaleFactorX, scaleFactorY, -Camera.main.transform.position.z);
    }
}
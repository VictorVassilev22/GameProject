using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFadeOut : MonoBehaviour
{
    public float fadeOutTime=1f;
    public static bool canFade = false;
    // Start is called before the first frame update
    void Update()
    {
        if(canFade)
            StartCoroutine(spriteFadeOut(GetComponent<SpriteRenderer>()));
    }

    IEnumerator spriteFadeOut(SpriteRenderer sprite)
    {
        Color tmpColor = sprite.color;
        while (tmpColor.a > 0f)
        {
            tmpColor.a -= Time.deltaTime / fadeOutTime;
            sprite.color = tmpColor;

            if (tmpColor.a <= 0f)
                tmpColor.a = 0f;

            yield return null;
        }

        sprite.color = tmpColor;
    }
}

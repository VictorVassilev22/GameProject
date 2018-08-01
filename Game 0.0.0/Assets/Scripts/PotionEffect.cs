using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotionEffect : MonoBehaviour {
    private static PotionEffect instance;
    private static  Transform myTransform;
    private static GameObject myEffect;
    private static float interval = 0.2f;

    private void Awake()
    {
        instance = this;
    }

    public static void ActivateEffect(Transform obj, GameObject effect)
    {
        myTransform = obj;
        myEffect = effect;
        instance.StartCoroutine(Interval());
        
    }

    static IEnumerator Interval()
    {
        for (int i = 0; i < 5; i++)
        {
            Vector2 offset = new Vector2(Random.Range(-0.9f, 0.9f), Random.Range(0.2f, 1.5f));
            GameObject potionEffect = Instantiate(myEffect, (Vector2)myTransform.position + offset, Quaternion.identity);
            potionEffect.transform.parent = myTransform;
            yield return new WaitForSeconds(interval);
        }
    }
}

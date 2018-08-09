
using UnityEngine;
using UnityEngine.UI;

public class CoinScript : MonoBehaviour {
    public static int coinCount = 0;
    // Update is called once per frame
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.name == "Player")
        {
            Destroy(this.gameObject);
            coinCount++;
        }
    }
}

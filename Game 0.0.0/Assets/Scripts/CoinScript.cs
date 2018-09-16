
using UnityEngine;
using UnityEngine.UI;

public class CoinScript : MonoBehaviour {
    public static int coinCount = 0;

    public Rigidbody2D rb;
    GameObject player;

    Vector2 playerDirection;
    float timeStamp;
    bool isInFieldRange=false;

    private void Start()
    {
        player = GameObject.Find("Player");
    }
    private void Update()
    {
        if (MagnetFieldActivation.magnetFieldEnabled && isInFieldRange)
        {
            playerDirection = -(transform.position - player.transform.position).normalized;
            rb.velocity = new Vector2(playerDirection.x, playerDirection.y) * 175f * (Time.time / timeStamp);
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.name.Equals("MagnetField") && MagnetFieldActivation.magnetFieldEnabled)
        {
            isInFieldRange = true;
            timeStamp = Time.time;
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.name == "Player")
        {
            Destroy(this.gameObject);
            coinCount++;
        }
    }
}

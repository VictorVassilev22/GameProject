using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour {

    public float health = 25.0f;
    public float moveSpeed;
    public Vector2 velocity; // По у е зададено на -1 в Unity
    public float experience = 12.5f;
    private GameObject gameCtrl;
    private GameController gameCtrlScript;

    public Rigidbody2D coin;
    public int coinCount = 5;

    private void Start()
    {
        Transform player = GameObject.Find("Player").transform;
        // Physics2D.IgnoreCollision(player.GetComponent<Collider2D>(), this.GetComponent<Collider2D>());
        gameCtrl = GameObject.Find("GameController");
        gameCtrlScript = gameCtrl.GetComponent<GameController>();
        moveSpeed = gameCtrlScript.enemySpd;
        this.GetComponent<Rigidbody2D>().velocity = new Vector2(velocity.x, velocity.y * transform.localScale.y * moveSpeed); //Zadawame skorost
        Physics2D.IgnoreLayerCollision(12,13);
    }

    void OnTriggerEnter2D(Collider2D col) // -the collision function and parameter must be for 2D
    {
        if (col.gameObject.name == "missle(Clone)") // check if the object colliding is the missle
        {
            GameObject missle = GameObject.Find("missle(Clone)");
            MissleScript missleScript = missle.GetComponent<MissleScript>();
            this.health -= missleScript.attack;
            Destroy(col.gameObject);

            if (health <= 0.0f)
            {
                for (int i = 0; i < coinCount; i++)
                {
                    Rigidbody2D coinInstance;
                    coinInstance = Instantiate(coin, this.transform.position, this.transform.rotation);
                    coinInstance.AddForce(new Vector2(Random.Range(-1, 1), Random.Range(-1, 1)) * Random.Range(-250, 250));
                }
                Destroy(this.transform.GetChild(1).gameObject);
                gameCtrlScript.score += experience;
            }
        }
    }
    void Update()
    {
        if (this.transform.position.y <= -13)
        {
            Destroy(this.gameObject);
            
        }
    }
}

using UnityEngine;
using System.Collections;

public class EnemyScript : MonoBehaviour
{
    public float health = 25.0f;
    public float moveSpeed = 1.0f;
    public Vector2 velocity; // По у е зададено на -1 в Unity
    public float experience = 12.5f;
    private GameObject gameCtrl;
    private GameController gameCtrlScript;

    private void Start()
    {
        this.GetComponent<Rigidbody2D>().velocity = new Vector2(velocity.x, velocity.y * transform.localScale.y*moveSpeed); //Zadawame skorost
        Transform player = GameObject.Find("Player").transform;
        Physics2D.IgnoreCollision(player.GetComponent<Collider2D>(), this.GetComponent<Collider2D>());
        gameCtrl = GameObject.Find("GameController");
        gameCtrlScript = gameCtrl.GetComponent<GameController>();
    }

    void OnCollisionEnter2D(Collision2D col) // -the collision function and parameter must be for 2D
    {
        if (col.gameObject.name == "missle(Clone)") // check if the object colliding is the missle
        {
            GameObject missle = GameObject.Find("missle(Clone)");
            MissleScript missleScript = missle.GetComponent<MissleScript>();
            this.health -= missleScript.attack;
            Destroy(col.gameObject);
            gameCtrlScript.score += experience;
        }

        if (health<=0.0f)
        {
            Destroy(this.gameObject);
            //Instantiate(explosion, transform.position, transform.rotation);
        }
    }

    void Update()
    {
        //this.moveSpeed+= gameCtrlScript.score / 1000f;
        if (this.transform.position.y<=-13)
        {
            Destroy(this.gameObject);
        }
    }
}
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

    private int chance;
    public int percentage = 5;

   

    public Rigidbody2D coin;
    public Rigidbody2D healthPotion;
    public Rigidbody2D manaPotion;

    public int coinCount = 5;

    private List<Rigidbody2D> dropOuts = new List<Rigidbody2D>();

    private void Start()
    {
        dropOuts.Add(healthPotion);
        dropOuts.Add(manaPotion);
        gameCtrl = GameObject.Find("GameController");
        gameCtrlScript = gameCtrl.GetComponent<GameController>();
        moveSpeed = GameController.enemySpd;
        this.GetComponent<Rigidbody2D>().velocity = new Vector2(velocity.x, velocity.y * transform.localScale.y * moveSpeed); //Zadawame skorost
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
                InstantiateCoins(coinCount);
                chance = Random.Range(0,100);
                InstantiateDropOut(chance, percentage, dropOuts[Random.Range(0, dropOuts.Count)]);
                 Destroy(this.gameObject);
                gameCtrlScript.score += experience;
            }
        }
    }

    void InstantiateDropOut(float chance, int percentage, Rigidbody2D dropOut)
    {
        if (chance <= percentage)
        {
            Rigidbody2D dropOutInstance;
            dropOutInstance = Instantiate(dropOut, this.transform.position, this.transform.rotation);
            dropOutInstance.AddForce(new Vector2(Random.Range(-1, 1), Random.Range(-1, 1)) * Random.Range(-500, 500));
        }
    }


    void InstantiateCoins(int count)
    {
        for (int i = 0; i < count; i++)
        {
            Rigidbody2D coinInstance;
            coinInstance = Instantiate(coin, this.transform.position, this.transform.rotation);
            coinInstance.AddForce(new Vector2(Random.Range(-1, 1), Random.Range(-1, 1)) * Random.Range(-250, 250));
        }
    }
}

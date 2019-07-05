using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthBar : MonoBehaviour
{
    private Transform bar;
    private float maxHealth;
    private float latestHealth;
    private EnemyScript enemy;

    public GameObject damageText;
    // Start is called before the first frame update
    void Start()
    {
        enemy = this.gameObject.GetComponent<EnemyScript>();
        bar = this.transform.GetChild(2).GetChild(1);
        maxHealth = enemy.health;
        latestHealth = enemy.health;
    }

    // Update is called once per frame
    void Update()
    {
        if (enemy.health < latestHealth)
        {
            GameController.ShowTextEffect(enemy.health-latestHealth, damageText, this.transform);
            latestHealth = enemy.health;
            bar.localScale = new Vector3(enemy.health / maxHealth, 1);
        }       
    }
}

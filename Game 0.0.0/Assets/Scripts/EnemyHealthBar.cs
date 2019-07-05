using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthBar : MonoBehaviour
{
    private Transform bar;
    private float maxHealth;
    private EnemyScript enemy;
    private float scaleX;
    private float scaleY;
    // Start is called before the first frame update
    void Start()
    {
        enemy = this.gameObject.GetComponent<EnemyScript>();
        bar = this.transform.GetChild(2).GetChild(1);
        maxHealth = enemy.health;
    }

    // Update is called once per frame
    void Update()
    {
        bar.localScale = new Vector3(enemy.health / maxHealth, 1);
    }
}

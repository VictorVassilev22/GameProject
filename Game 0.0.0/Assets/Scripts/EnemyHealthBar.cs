using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthBar : MonoBehaviour
{
    private Transform bar;
    private float maxHealth;
    private EnemyScript enemy;
    private GameObject barObject;


    public float showBarTime;

    public GameObject damageText;
    public GameObject critText;

    // Start is called before the first frame update
    void Start()
    {
        enemy = this.gameObject.GetComponent<EnemyScript>();
        bar = this.transform.GetChild(2).GetChild(1);
        maxHealth = enemy.health;
        barObject = this.gameObject.transform.GetChild(2).gameObject;
        barObject.SetActive(false);       
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void EnemyGetsHit(float missleAttack, float actualAttack)
    {
        StartCoroutine(ShowHealthBar(showBarTime));
        //ako e poveche ot missle.attack => crit
        if (actualAttack>missleAttack)
            GameController.ShowTextEffect(-actualAttack, critText, this.transform); //change damageText to critText
        else
            GameController.ShowTextEffect(-actualAttack, damageText, this.transform);

        bar.localScale = new Vector3(enemy.health / maxHealth, 1);
       
    }

    IEnumerator ShowHealthBar(float time)
    {
        barObject.SetActive(true);
        yield return new WaitForSeconds(time);
        barObject.SetActive(false);
    }
}

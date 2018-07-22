using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootMissle : MonoBehaviour
{

    public GameObject missle; //Нашата летяща топка
    public Vector2 velocity; //Скоростта, която е зададена на 14 по оста 'y' от Unity
    bool canShoot = true; //Дали може да стреля
    public Vector2 offset = new Vector2(0f, 0.5f); //Разтоянието от което магьосника си прави топката
    public float cooldown = 0.8f; //Cooldown на изстрела
    public float chargeTime = 0.6f; //Времето за зареждане на изстрела
    private Animator animation; 

    // Use this for initialization
    void Start()
    {
         animation = GetComponent<Animator>(); //закачаме нашия аниматор за animate
    }

    // Update is called once per frame
    void Update()
    {
#if UNITY_ANDROID //При андроид използваме тъч системата
          if (Input.touches.Length>0 && canShoot) //Ако повече от 1 пръст е поставен на екрана и героят ни може да стреля:
        {
            animation.SetTrigger("shootTrigger"); //задействаме анимацията
            StartCoroutine(Charge()); // топката се зарежда и изстрелва
            StartCoroutine(ShootCooldown()); //пускаме cooldown
        }
#endif
        if (Input.GetMouseButtonDown(0) && canShoot)
        { //abe sushtoto ama za komp
            animation.SetTrigger("shootTrigger");
            StartCoroutine(Charge());
            StartCoroutine(ShootCooldown());
            ManaBarScript.mana -= 10f;
        }
    }


    IEnumerator Charge()
    {
        yield return new WaitForSeconds(chargeTime); //Чакаме времето докато анимацията върви
        Shoot(); // стреляме
    }

    void Shoot()
    {
        GameObject firedMissle = (GameObject)Instantiate(missle, (Vector2)transform.position + offset * transform.localScale.y, Quaternion.identity); //Spawn-ваме топката на даденото разстояние пред героя
        firedMissle.GetComponent<Rigidbody2D>().velocity = new Vector2(velocity.x, velocity.y * transform.localScale.y); //Задаваме скоростта на топката по оста 'Y'

    }

    IEnumerator ShootCooldown()
    {
        canShoot = false; //героя вече не може да стреля
        yield return new WaitForSeconds(cooldown); //чакаме даденото време
        canShoot = true; // пак може да стреля
        ManaBarScript.mana += 5f;
    }

}

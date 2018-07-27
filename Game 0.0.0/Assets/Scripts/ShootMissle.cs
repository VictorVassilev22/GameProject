using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ShootMissle : MonoBehaviour
{

    public GameObject missle; //Нашата летяща топка
    public Vector2 velocity; //Скоростта, която е зададена на 14 по оста 'y' от Unity
    public bool canShoot = true; //Дали може да стреля
    public Vector2 offset = new Vector2(0f, 0.3f); //Разтоянието от което магьосника си прави топката
    public float cooldown =0.6f; //Cooldown на изстрела
    public float chargeTime = 0.432f; //Времето за зареждане на изстрела
    public float manaCost = 5f;
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
          if (Input.touches.Length>0 && canShoot && !IsPointerOverUIObject() && ManaBarScript.hasManaForMissle) //Ако повече от 1 пръст е поставен на екрана и героят ни може да стреля:
        {
            animation.SetTrigger("shootTrigger"); //задействаме анимацията
            StartCoroutine(Charge()); // топката се зарежда и изстрелва
            StartCoroutine(ShootCooldown()); //пускаме cooldown
            if (ManaBarScript.mana - manaCost >= 0)
            {
                ManaBarScript.mana -= manaCost;
            }
        }
#endif
        if (Input.GetMouseButtonDown(0) && canShoot && !IsPointerOverUIObject() && ManaBarScript.hasManaForMissle)
        { //abe sushtoto ama za komp
            animation.SetTrigger("shootTrigger");
            StartCoroutine(Charge());
            StartCoroutine(ShootCooldown());
            if (ManaBarScript.mana-manaCost>=0)
            {
                ManaBarScript.mana -= manaCost;
            }
        }
  
    }

    private bool IsPointerOverUIObject()
    {
        PointerEventData eventDataCurrentPosition = new PointerEventData(EventSystem.current);
        eventDataCurrentPosition.position = new Vector2(Input.mousePosition.x, Input.mousePosition.y);

        List<RaycastResult> results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(eventDataCurrentPosition,results);
        return results.Count > 0;
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
        if (GameController.gameRunning) canShoot = true; // пак може да стреля

    }
}

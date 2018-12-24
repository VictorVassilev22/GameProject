using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class LongPressSpell : Selectable, IPointerDownHandler, IPointerUpHandler {

    public int spellNember;

    public static bool pointerDown;
    private bool longPressActivated;
    private bool shortCooldownActive;
    private bool longCooldownActive;
    private GameObject Player;
    private float time = 0;
    private float count;
    private float cooldown;
    private Animator animation;

    public float manaCost;
    public int spellCount;
    public float longCooldown;
    public float shortCooldown;

    [SerializeField]
    private Image fillCooldownImage;

    private SpellController spellController;
    
   
    private void Start()
    {
        count = spellCount;
        Player = GameObject.Find("Player");
        animation =Player.GetComponent<Animator>();
        spellController = Player.GetComponent<SpellController>();
    }


    override public void OnPointerDown(PointerEventData eventData)
    {
        if (cooldown == 0&&this.interactable)
        {
            pointerDown = true;
        }
    }

    override public void OnPointerUp(PointerEventData eventData)
    {
        if (longPressActivated)
        {
            animation.Play("shootFireball");
            longPressActivated = false;
        }
        pointerDown = false;
        Player.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionY | RigidbodyConstraints2D.FreezeRotation;
        if (cooldown == 0&&this.interactable)
        {
            if (count==spellCount)ManaBarScript.mana -= manaCost;
            if (time < 0.5 || (count < spellCount && count > 0))
            {
                animation.Play("fireball");
                spellController.castSpell(spellNember, 0);
                count--;
            }
            else if (count == spellCount)
            {
                count = 0;
            }


            if (count > 0)
            {
                shortCooldownActive = true;
                cooldown = shortCooldown;
            }
            else
            {
                longCooldownActive = true;
                cooldown = longCooldown;
            }
        }

        time = 0;
    }

    
	// Update is called once per frame
	void Update ()
    {

        if (pointerDown)
        {
            time += Time.deltaTime;

            if (time > 0.5f && count == spellCount)
            {
                if(!longPressActivated) spellController.castSpell(spellNember, 1);
                animation.Play("bigFireball");
                longPressActivated = true;
                Player.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezePositionY| RigidbodyConstraints2D.FreezeRotation;
            }
        }
      

        if (cooldown > 0)
        {
            cooldown -= Time.deltaTime;
            if (longCooldownActive)
            {
                fillCooldownImage.fillAmount = cooldown / longCooldown;
            }
            else if(shortCooldownActive)
            {
                fillCooldownImage.fillAmount = cooldown / shortCooldown;
            }
           
        }
        else
        {
            cooldown = 0;
            longCooldownActive = false;

            if(shortCooldownActive)
            shortCooldownActive = false;

            if(count==0)
            count = spellCount;
        }

        if (ManaBarScript.mana < manaCost && (count==spellCount||count==0) || !ShootMissle.canShoot)
        {
            this.interactable = false;
            this.image.color = this.colors.disabledColor;
        }
        else
        {
            this.interactable = true;
            this.image.color = this.colors.normalColor;
        }

	}
}

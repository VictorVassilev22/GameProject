using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellController : MonoBehaviour {

    [SerializeField]
    private GameObject spell_00;
    [SerializeField]
    private GameObject spell_01;

    [SerializeField]
    private Vector2 offset_1;
    [SerializeField]
    private Vector2 offset_2;
    [SerializeField]

    private Vector2 velocity;

    [SerializeField]
    private float chargeTime0;

    private LongPressSpell spellButton;
    private GameObject bigFireball;
    private bool isType1;
    private int spellNumber;
    private Animator animation;
    private GameObject Player;


    private float bigFireballPusher = 0.03f;
    public void castSpell(int spellNum, int spellType)
    {
        spellNumber = spellNum;
        switch (spellNumber)
        {
            case 0:
                castFireball(spellType);
                break;
            default:
                return;
        }
    }
    
    private void castFireball(int spellType)
    {
        switch (spellType)
        {
            case 0:
                StartCoroutine(castMissleType(chargeTime0, spell_00));
                break;
            case 1:
                isType1 = true;
                StartCoroutine(castLongPressType(spell_01));
                break;
            default:
                return;

        }
    }

    IEnumerator castMissleType(float chargeTime, GameObject spell)
    {
        yield return new WaitForSeconds(chargeTime);
        GameObject missle = Instantiate(spell, (Vector2)transform.position + offset_1 * transform.localScale.y, Quaternion.identity); //Spawn-ваме топката на даденото разстояние пред героя
        missle.GetComponent<Rigidbody2D>().velocity = new Vector2(velocity.x, velocity.y * transform.localScale.y); //Задаваме скоростта на топката по оста 'Y'
    }

    IEnumerator castLongPressType(GameObject spell)
    {
        yield return new WaitForSeconds(0.25f);
        bigFireball = Instantiate(spell, (Vector2)transform.position + offset_2 * transform.localScale.y, Quaternion.identity); //Spawn-ваме топката на даденото разстояние пред героя
        
    }

    void Start () {
        animation =this.GetComponent<Animator>();
        Player = GameObject.Find("Player");
	}
	
	// Update is called once per frame
	void Update () {
		if(isType1)
        {
            if (spellNumber == 0 && LongPressSpell.pointerDown && bigFireball.transform.localScale.x < 6)
            {
                
                    bigFireball.gameObject.transform.localScale += new Vector3(0.01f, 0.01f);
                    //bigFireball.gameObject.GetComponent<MissleScript>().attack+=0.5f;
                    bigFireball.gameObject.transform.localPosition += new Vector3(0.00f, bigFireballPusher);
                    if(bigFireballPusher>0) bigFireballPusher -= 0.0005f;

            }
            else
            {
                isType1 = false;
                bigFireball.GetComponent<Rigidbody2D>().velocity = new Vector2(velocity.x, velocity.y * transform.localScale.y); //Задаваме скоростта на топката по оста 'Y'
                animation.Play("shootFireball");
                LongPressSpell.pointerDown = false;
                LongPressSpell.longPressActivated = false;
                Player.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionY | RigidbodyConstraints2D.FreezeRotation;           
                bigFireballPusher = 0.03f;
            }
        }

    }
}

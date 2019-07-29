using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class DialogBoxOpen : MonoBehaviour
{
    private GameObject tailor;
    private GameObject player;
    private GameObject dialogBox;
    private Text tailorOffer;
    private bool active;

    private string[] phrases = new string[5];

    public GameObject button;
    // Start is called before the first frame update
    void Start()
    {
        tailor = this.transform.parent.gameObject;
        player = GameObject.Find("Player");
        dialogBox = GameObject.Find("TailorDialogBox");
        button = GameObject.Find("TailorButton");
        tailorOffer = dialogBox.transform.GetChild(0).GetComponent<Text>();
        phrases[0] = "Want some brand new clothing?";
        phrases[1] = "Looking for some robes? Here i am!";
        phrases[2] = "Rune enchanted robes only here!";
        phrases[3] = "Never go on a quest without a robe!";
        phrases[4] = "I will show you the best robes I've got!";
    }

    // Update is called once per frame
    void Update()
    {
        if (System.Math.Abs(tailor.transform.position.x - player.transform.position.x) > tailor.transform.Find("Radius").GetComponent<CircleCollider2D>().radius
            || System.Math.Abs(tailor.transform.position.y - player.transform.position.y) > tailor.transform.Find("Radius").GetComponent<CircleCollider2D>().radius)
        {
            active = false;
        }

        if(active)
        {            
            dialogBox.SetActive(true);
            button.SetActive(true);
        }
        else
        {
            dialogBox.SetActive(false);
            button.SetActive(false);
        }
    }

    void OnTriggerEnter2D( Collider2D col)
    {
       if(col.gameObject.name == "Player")
        {
            tailorOffer.text = phrases[Random.Range(0, 5)];
            Debug.Log("active");
            active = true;
        }
            
    }
}

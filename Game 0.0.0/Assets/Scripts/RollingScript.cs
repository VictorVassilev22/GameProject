using UnityEngine;
using System.Collections;


public class RollingScript : MonoBehaviour {

    public float speed = 0.5f;
    private GameObject gameCtrl;
    private GameController gameCtrlScript;

    // Use this for initialization
    void Start () {
        gameCtrl = GameObject.Find("GameController");
        gameCtrlScript = gameCtrl.GetComponent<GameController>();
    }
	
	// Update is called once per frame
	void Update () {

        Vector2 offset = new Vector2(0, Time.time * speed);
        GetComponent<Renderer>().material.mainTextureOffset = offset;
        this.speed += gameCtrlScript.score / 100000000f + 0.000003f;
	}
}

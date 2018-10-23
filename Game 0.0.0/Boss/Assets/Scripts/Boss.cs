using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour {
    
    public List<Transform> spots;
    public float speed;
    public Transform[] holes;
    public GameObject projectile;
    public Rigidbody2D rb;

	
	void Start () {
        GameObject[] gameObjects = GameObject.FindGameObjectsWithTag("Spot");
        
        foreach (GameObject spot in gameObjects) 
        {
            spots.Add(spot.transform);
            if (System.Math.Abs(transform.position.magnitude) < 0.1)
                throw new System.Exception("Da pripadash");
        }
        StartCoroutine ("boss");
        //gggg
		
	}


    void Update()
    {
        StartCoroutine("boss");
    }
    IEnumerator boss()
    {

        //First attack
        /*while (transform.position.x!=spots[0].position.x)
        {
            transform.position = Vector2.MoveTowards(transform.position, new Vector2(spots[0].position.x, transform.position.y),speed);
            yield return null;
        }
        transform.localScale = new Vector2(-1,1);

        yield return new WaitForSeconds(1f);

        int i = 0;
        while (i<6){
            GameObject bullet =(GameObject)Instantiate(projectile, holes[c].position,Quaternion.identity);
            bullet.GetComponent<Rigidbody2D>().velocity = Vector2.left * 5;
            i++;
            yield return new WaitForSeconds(.7f);
        }
        yield return null;*/
        GameObject[] gameObjects = GameObject.FindGameObjectsWithTag("Spot");
        spots.Clear();
        foreach (GameObject spot in gameObjects)
        {
            spots.Add(spot.transform);
        }
        int spotToGo = 0; //random value
        speed = 0.1f;
        Vector3 directionToSpot = (spots[spotToGo].position - transform.position);
        transform.position += directionToSpot.normalized * this.speed;
        //rb.velocity =new Vector2(directionToSpot.x, directionToSpot.y).normalized * this.speed;

        yield return null;
	}
     
}

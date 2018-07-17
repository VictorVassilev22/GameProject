using UnityEngine;
using System.Collections;

public class DestroyByContact : MonoBehaviour
{
    public GameObject explosion;
    void OnCollisionEnter2D(Collision2D col) // -the collision function and parameter must be for 2D
    {
        if (col.gameObject.name == "missile(Clone)") // check if the object colliding is the missle
        {
            Instantiate(explosion, transform.position, transform.rotation);
            Destroy(col.gameObject);//destroy the missle
            Destroy(this.gameObject); //destroy the enemy
        }
    }
}
using UnityEngine;
using System.Collections;

public class DestroyByContact : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        //Ako tova go nqma kato cukna Play mi premahva gameobject-a i Banudary-to ,toest dwata Cube-a.Vidqh v internet kak go oprawqt
        if (other.tag == "Boundary") 
        { 
            return;
        }

        Destroy(other.gameObject); //- Destroys the ball when hit the Enemy
        Destroy(gameObject); //-Destroys the enemy
    }
}

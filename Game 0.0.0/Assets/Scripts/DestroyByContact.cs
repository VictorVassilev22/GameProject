using UnityEngine;
using System.Collections;

public class DestroyByContact : MonoBehaviour
{
    public GameObject enemy;
    void OnTriggerEnter(Collider other)
    {
        Destroy(other.gameObject); //- Destroys the ball when hit the Enemy
        Destroy(enemy); //-Destroys the enemy
    }
}

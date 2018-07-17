using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

    public GameObject hazard;
    public Vector2 spawnValues;
    private bool canSpawn = true;
    public float cooldown = 1.0f;
    void Update()
    {
        if(canSpawn)
        SpawnWaves();
    }

    void SpawnWaves()
    {
        Vector2 spawnPosition = new Vector2(Random.Range (-spawnValues.x ,spawnValues.x) ,spawnValues.y);
        Quaternion spawnRotation = Quaternion.identity;
        Instantiate(hazard, spawnPosition, spawnRotation);
        StartCoroutine(StartCooldown());
    }

    IEnumerator StartCooldown()
    {
        canSpawn = false;
        yield return new WaitForSeconds(cooldown);
        canSpawn = true;
    }
}

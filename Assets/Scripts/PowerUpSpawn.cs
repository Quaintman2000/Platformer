using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpSpawn : MonoBehaviour
{
    // power up to spawn
    public GameObject powerupPrefab;

    public GameObject spawnedPowerUp = null;

    private void Start()
    {
        //spawn the powerup token at start
        SpawnPowerUp();
    }

    public void SpawnPowerUp()
    {
        //if there isnt a spawned coin
        if (spawnedPowerUp == null)
        {
            //spawn a coin on its position
            spawnedPowerUp = Instantiate(powerupPrefab, transform.position, Quaternion.identity);
        }
    }
}

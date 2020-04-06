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
        SpawnPowerUp();
    }

    public void SpawnPowerUp()
    {
        if (spawnedPowerUp == null)
        {
            spawnedPowerUp = Instantiate(powerupPrefab, transform.position,Quaternion.identity);
        }
    }
}

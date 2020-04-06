using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawnPoint : MonoBehaviour
{
    private void Awake()
    {
        //set the starting spawn point
        GameManager.instance.SpawnPointGameObject = this.gameObject;
        //respawn player at immiediately at where the spawn point is at.
        GameManager.instance.Respawn();
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //if the player is not in the scene, most likely destroyed, respawn
        if (GameManager.instance.playerTransform == null)
        {
            GameManager.instance.Respawn();
        }
    }
}

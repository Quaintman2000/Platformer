using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawnPoint : MonoBehaviour
{
    private void Awake()
    {
        GameManager.instance.SpawnPointGameObject = this.gameObject;
        GameManager.instance.Respawn();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(GameManager.instance.playerTransform == null)
        {
            GameManager.instance.Respawn();
        }
    }
}

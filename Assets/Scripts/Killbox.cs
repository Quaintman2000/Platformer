using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Killbox : MonoBehaviour
{
    //if the player falls out of the world and into the kill box
    private void OnTriggerEnter2D(Collider2D other)
    {
        //destroy the player
        Destroy(other.gameObject);
        //subtract a life
        GameManager.instance.playerLives--;

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndLevel : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //if player enters the the collider of this object, then load next level
        if(collision.gameObject.name == "Player")
        {
            GameManager.instance.LoadNextScene();
        }
    }
}

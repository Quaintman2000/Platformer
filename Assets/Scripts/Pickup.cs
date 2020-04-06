using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    //adds points when the player picks up the coin
    public int points;

    //audio clip to play when pick up is collected;
    public AudioClip audioClip;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        // if interacted with the players
        if (collision.gameObject.tag == "Player")
        {
            //reward the player with points.
            GameManager.instance.playerScore += points;
            //Play Coid sound effect.
            AudioSource.PlayClipAtPoint(audioClip, transform.position);
            //Destroy the coin.
            Destroy(this.gameObject);
        }
    }
}

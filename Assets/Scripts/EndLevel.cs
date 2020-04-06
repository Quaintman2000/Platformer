using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndLevel : MonoBehaviour
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
        if (collision.gameObject.tag == "Player")
        {
            //reward the player with points.
            GameManager.instance.playerScore += points;
            //Play Coid sound effect.
            AudioSource.PlayClipAtPoint(audioClip, transform.position);
            //if on the last level
            if (GameManager.instance.currentScene == 3)
            {
                GameManager.instance.LoadLevel(4);
            }
            else
            {
                GameManager.instance.LoadNextScene();
            }
            //Destroy the coin.
            Destroy(this.gameObject);
            Destroy(collision.gameObject);
            
        }
    }
}

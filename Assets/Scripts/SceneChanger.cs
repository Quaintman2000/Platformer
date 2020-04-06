using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneChanger : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // these were just to text the scene changing to see if it worked
        //if i press U
        if (Input.GetKeyDown(KeyCode.U))
        {
            //go to next scene
            GameManager.instance.LoadNextScene();
        }
        // if i press O
        if (Input.GetKeyDown(KeyCode.O))
        {
            //go to main menu
            GameManager.instance.LoadLevel(0);
        }
    }
}

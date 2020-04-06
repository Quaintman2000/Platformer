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
        if (Input.GetKeyDown(KeyCode.U))
        {
            GameManager.instance.LoadNextScene();
        }
        if (Input.GetKeyDown(KeyCode.O))
        {
            GameManager.instance.LoadLevel(0);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GrabCollision : MonoBehaviour
{


    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Failed")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);

        }
        if(collision.name == "Hand")
        {
            SceneManager.LoadScene("MainScene");
        }
    }
}

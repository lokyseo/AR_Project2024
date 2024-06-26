using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class JumpKing_Player : MonoBehaviour
{
    void Start()
    {
    }

    void Update()
    {

    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.name == "Goal")
        {
            SceneManager.LoadScene("MainScene");
        }

        if(collision.gameObject.tag == "Failed")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);

        }
    }
}

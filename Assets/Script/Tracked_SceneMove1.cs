using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Tracked_SceneMove1 : MonoBehaviour
{


    void Start()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        SceneManager.LoadScene("Test2_Tracked");
        


    }

    void Update()
    {
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Tracked_SceneMove : MonoBehaviour
{
    float timeCount;
    private void OnEnable()
    {
        timeCount = 1.0f;
    }

    void Start()
    {
        timeCount = 1.0f;

    }

    void Update()
    {
        timeCount -= Time.deltaTime;
        if(timeCount < 0.0f)
        {
            timeCount = 1.0f;
            
            this.gameObject.SetActive(false);

            SceneManager.LoadScene("Test1_Tracked");
            Camera.main.Reset();

        }


    }
}

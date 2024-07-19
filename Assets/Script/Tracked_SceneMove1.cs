using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Tracked_SceneMove1 : MonoBehaviour
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
        if (timeCount < 0.0f)
        {
            timeCount = 1.0f;

            SceneManager.LoadScene(3);

        }
    }
}

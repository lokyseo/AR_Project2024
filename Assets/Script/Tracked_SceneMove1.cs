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
        if (this.gameObject.activeSelf)
        {
            //ARManager.isTrackingSuccess = true;
            //Destroy(this.gameObject);

        }

    }

    void Update()
    {
        timeCount -= Time.deltaTime;
        if (timeCount < 0.0f)
        {
            timeCount = 1.0f;
            for(int i = 1; i < 5; i++)
            {
                if (this.gameObject.name.Contains("test" + i))
                {
                    SceneManager.LoadScene("Test" + i + "_Tracked");

                }
            }
            

        }
    }
}

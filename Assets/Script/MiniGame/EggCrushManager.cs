using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EggCrushManager : MonoBehaviour
{
    public Text textCount;
    float touchCount;
    void Start()
    {
        touchCount = 100;
        textCount.text = touchCount.ToString();
    }

    void Update()
    {
        if (Input.touchCount > 0)
        {
            for(int i = 0; i < Input.touchCount; i++)
            {
                Touch touch = Input.GetTouch(i);


                if (touch.phase == TouchPhase.Began)
                {
                    touchCount--;

                    if(touchCount < 0)
                    {
                        SceneManager.LoadScene("MainScene");
                        textCount.text = "0";

                    }
                    else
                    {
                        textCount.text = touchCount.ToString();

                    }


                }


                if (touch.phase == TouchPhase.Ended)
                {

                }


            }

        }
    }
}

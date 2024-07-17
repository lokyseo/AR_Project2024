using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EggCrushManager : MonoBehaviour
{
    public Text textCount;
    public Image filled_Image;
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
                    if (touchCount <= 0)
                    {
                        PlayerPrefs.SetInt("MiniGame4Clear", 1);
                        SceneManager.LoadScene("MainScene");
                        textCount.text = "0";

                    }
                    else
                    {
                        touchCount--;
                        filled_Image.fillAmount += 0.01f;
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

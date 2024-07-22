using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EggCrushManager : MonoBehaviour
{
    public Text textCount;
    public Image filled_Image;
    float touchCount;

    float clearTime;
    public TextMeshProUGUI time_Text;

    void Start()
    {
        touchCount = 100;
        textCount.text = touchCount.ToString();
        clearTime = 10.0f;
    }

    void Update()
    {
        clearTime -= Time.deltaTime;
        time_Text.text = clearTime.ToString("F1");

        if (clearTime < 0 )
        {
            time_Text.text = "0.0";
            SceneManager.LoadScene("MainScene");
        }



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


            }

        }
    }
}

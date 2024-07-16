using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RememberColorMiniGame : MonoBehaviour
{
    public Image screen_Image;
    public Button[] buttons; //0: °Ë, 1: »¡, 2: ³ì, 3: ÆÄ
    public Sprite correct_Image;
    public Sprite wrong_Image;
    Color[] screenColor_Array;

    private float changeTime;
    private int countChane;
    private int buttonCount;
    int randColor;
    public bool isGameStart;
    void Start()
    {
        buttonCount = 0;
        countChane = 0;
        isGameStart = false;
        screenColor_Array = new Color[5];
    }

    void Update()
    {
        if (isGameStart)
        {
            changeTime -= Time.deltaTime;
            if (changeTime < 0)
            {
                randColor = Random.Range(0, 4);
                switch (randColor)
                {
                    case 0:
                        screen_Image.color = Color.red;
                        break;
                    case 1:
                        screen_Image.color = Color.green;
                        break;
                    case 2:
                        screen_Image.color = Color.blue;
                        break;
                    case 3:
                        screen_Image.color = Color.black;
                        break;
                }
                screenColor_Array[countChane] = screen_Image.color;
                countChane++;
                if (countChane == 5) isGameStart = false;
                changeTime = 1.5f;
            }
            else if(changeTime < 0.1f)
            {
                screen_Image.color = Color.white;
            }

        }
    }

    public void OnClickBlackButton()
    {
        if(!isGameStart && buttonCount < 5)
        {
            Color color = buttons[0].GetComponent<Image>().color;
            if (color == screenColor_Array[buttonCount])
            {
                screen_Image.sprite = correct_Image;
            }
            else
            {
                screen_Image.sprite = wrong_Image;
            }
            buttonCount++;
        }
    }
    public void OnClickRedButton()
    {
        if (!isGameStart && buttonCount < 5)
        {
            Color color = buttons[1].GetComponent<Image>().color;
            screen_Image.color = color;
            if (color == screenColor_Array[buttonCount])
            {
                screen_Image.sprite = correct_Image;
            }
            else
            {
                screen_Image.sprite = wrong_Image;
            }
            buttonCount++;
        }
    }
    public void OnClickGreenButton()
    {
        if (!isGameStart && buttonCount < 5)
        {
            Color color = buttons[2].GetComponent<Image>().color;
            screen_Image.color = color;
            if (color == screenColor_Array[buttonCount])
            {
                screen_Image.sprite = correct_Image;
            }
            else
            {
                screen_Image.sprite = wrong_Image;
            }
            buttonCount++;
        }
    }
    public void OnClickBlueButton()
    {
        if (!isGameStart && buttonCount < 5)
        {
            Color color = buttons[3].GetComponent<Image>().color;
            screen_Image.color = color;
            if (color == screenColor_Array[buttonCount])
            {
                screen_Image.sprite = correct_Image;
            }
            else
            {
                screen_Image.sprite = wrong_Image;
            }
            buttonCount++;
        }
    }
}

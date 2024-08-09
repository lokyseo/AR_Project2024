using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SwipeLeftRight_Manager : MonoBehaviour
{
    private Vector2 startTouchPosition, endTouchPosition;
    private float minSwipeDistance = 50f;

    public GameObject pulling_Object;
    public Sprite leftSprite;
    public Sprite righttSprite;
    float[] tempPosition;

    int score;
    public TextMeshProUGUI text_Score;
    void Start()
    {
        int sortnumber = pulling_Object.transform.childCount;
        tempPosition = new float[pulling_Object.transform.childCount];
        score = 0;

        for (int i = 0; i < pulling_Object.transform.childCount; i++)
        {
            int randNum = Random.Range(0, 2);
            if(randNum == 0)//哭率
            {
                pulling_Object.transform.GetChild(i).GetComponent<SpriteRenderer>().sprite = leftSprite;
                pulling_Object.transform.GetChild(i).GetComponent<SpriteRenderer>().color = Color.black;
                pulling_Object.transform.GetChild(i).tag = "Left";
            }
            else//坷弗率
            {
                pulling_Object.transform.GetChild(i).GetComponent<SpriteRenderer>().sprite = righttSprite;
                pulling_Object.transform.GetChild(i).tag = "Right";
            }

            if(i == 0)
            {
                pulling_Object.transform.GetChild(i).localPosition =
                new Vector3(0, pulling_Object.transform.GetChild(i).localPosition.y, -1);
            }
            else
            {
                pulling_Object.transform.GetChild(i).localPosition =
                    new Vector3(0, pulling_Object.transform.GetChild(i - 1).localPosition.y + 100, -1);
            }
            pulling_Object.transform.GetChild(i).localScale = new Vector3(250 - 15 * i, 250 - 15 * i, 250 - 15 * i);
            pulling_Object.transform.GetChild(i).GetComponent<SpriteRenderer>().sortingOrder = sortnumber;
            sortnumber--;

            tempPosition[i] = pulling_Object.transform.GetChild(i).localPosition.y;
        }
    }
    void Update()
    {

        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                startTouchPosition = touch.position;
            }
            else if (touch.phase == TouchPhase.Ended)
            {
                endTouchPosition = touch.position;
                DetectSwipe();
            }
        }

    }
    private void DetectSwipe()
    {
        if (Vector2.Distance(startTouchPosition, endTouchPosition) >= minSwipeDistance)
        {
            Vector2 direction = endTouchPosition - startTouchPosition;
            if (Mathf.Abs(direction.x) > Mathf.Abs(direction.y))
            {
                if (direction.x > 0)
                {
                    if (pulling_Object.transform.GetChild(0).tag == "Right")
                    {
                        score++;
                    }
                    else
                    {
                        score--;
                    }

                }
                else
                {
                    if (pulling_Object.transform.GetChild(0).tag == "Left")
                    {

                        score++;
                    }
                    else
                    {

                        score--;
                    }
                }
                text_Score.text = score.ToString();
                int randNum = Random.Range(0, 2);
                if (randNum == 0)//哭率
                {
                    pulling_Object.transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = leftSprite;
                    pulling_Object.transform.GetChild(0).GetComponent<SpriteRenderer>().color = Color.black;
                    pulling_Object.transform.GetChild(0).tag = "Left";
                }
                else//坷弗率
                {
                    pulling_Object.transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = righttSprite;
                    pulling_Object.transform.GetChild(0).GetComponent<SpriteRenderer>().color = Color.white;
                    pulling_Object.transform.GetChild(0).tag = "Right";
                }

                pulling_Object.transform.GetChild(0).SetSiblingIndex(pulling_Object.transform.childCount);

                int sortnumber = pulling_Object.transform.childCount;
                for (int i = 0; i < pulling_Object.transform.childCount; i++)
                {
                    pulling_Object.transform.GetChild(i).localPosition =
                        new Vector3(0, tempPosition[i], -1);

                    pulling_Object.transform.GetChild(i).localScale = new Vector3(250 - 15 * i, 250 - 15 * i, 250 - 15 * i);
                    pulling_Object.transform.GetChild(i).GetComponent<SpriteRenderer>().sortingOrder = sortnumber;
                    sortnumber--;
                }

                

            }
        }
    }
}

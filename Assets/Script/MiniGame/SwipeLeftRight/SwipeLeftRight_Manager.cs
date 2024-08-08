using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwipeLeftRight_Manager : MonoBehaviour
{
    private Vector2 startTouchPosition, endTouchPosition;
    private float minSwipeDistance = 50f;

    public GameObject pulling_Object;
    public Sprite leftSprite;
    public Sprite righttSprite;


    void Start()
    {
        int sortnumber = 0;
        for(int i = 0; i < pulling_Object.transform.childCount; i++)
        {
            int randNum = Random.Range(0, 2);
            if(randNum == 0)//¿ÞÂÊ
            {
                pulling_Object.transform.GetChild(i).GetComponent<SpriteRenderer>().sprite = leftSprite;
                pulling_Object.tag = "Left";
            }
            else//¿À¸¥ÂÊ
            {
                pulling_Object.transform.GetChild(i).GetComponent<SpriteRenderer>().sprite = righttSprite;
                pulling_Object.tag = "Right";
            }

            if(i == 0)
            {
                pulling_Object.transform.GetChild(i).localPosition =
                new Vector3(pulling_Object.transform.GetChild(i).localPosition.x, pulling_Object.transform.GetChild(i).localPosition.y, -1);
            }
            else
            {
                pulling_Object.transform.GetChild(i).localScale = new Vector3(150 + 10 * i, 150 + 10 * i, 150 + 10 * i);
                pulling_Object.transform.GetChild(i).localPosition =
                    new Vector3(pulling_Object.transform.GetChild(i).localPosition.x, pulling_Object.transform.GetChild(i - 1).localPosition.y - 100, -1);
            }

            pulling_Object.transform.GetChild(i).GetComponent<SpriteRenderer>().sortingOrder = sortnumber;
            sortnumber++;
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
                   
                }
                else
                {
                   
                }
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunLeftRight : MonoBehaviour
{
    private Vector2 startTouchPosition, endTouchPosition;
    private float minSwipeDistance = 50f;
    GameObject player_Object;
    public GameObject total_Obstacle;

    public GameObject obstacle;


    void Start()
    {
        player_Object = GameObject.FindWithTag("Player");
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
                    player_Object.transform.localPosition += new Vector3(360, 0, 0);
                }
                else
                {
                    player_Object.transform.localPosition += new Vector3(-360, 0, 0);
                }
            }
        }
    }
}

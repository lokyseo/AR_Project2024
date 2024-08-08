using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FindPair_Swipe : MonoBehaviour
{
    private Vector2 startTouchPosition, endTouchPosition;
    private float minSwipeDistance = 50f;

    void Start()
    {

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
                    if (transform.localPosition.x >= 300)
                        return;
                    transform.localPosition += new Vector3(300, 0, 0);
                }
                else
                {
                    if (transform.localPosition.x <= -300)
                        return;
                    transform.localPosition += new Vector3(-300, 0, 0);
                }
            }
        }
    }


}

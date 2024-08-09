using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class Oiled_Machine_Manager : MonoBehaviour
{
    private Vector2 startTouchPosition, currentTouchPosition;
    private float minSwipeDistance = 50f;

    bool isTouching;
    float swipeCount;

    public GameObject targetObject;

    void Start()
    {
        isTouching = false;
    }
    void Update()
    {

        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            //RectTransformUtility.RectangleContainsScreenPoint(targetUIElement, touch.position, null);
            if (IsTouchingObject(touch))
            {
                if (touch.phase == TouchPhase.Began)
                {
                    startTouchPosition = touch.position;

                    isTouching = true;

                }
                else if (touch.phase == TouchPhase.Moved)
                {

                    currentTouchPosition = touch.position;
                    DetectSwipe();

                }
                else if (touch.phase == TouchPhase.Ended)
                {
                    isTouching = false;
                }
            }
        }
    }

    bool IsTouchingObject(Touch touch)
    {
        Vector2 touchPosition = Camera.main.ScreenToWorldPoint(touch.position);

        RaycastHit2D hit = Physics2D.Raycast(touchPosition, Vector2.zero);

        return hit.collider != null && hit.collider.gameObject == targetObject;
    }
    private void DetectSwipe()
    {
        if (Vector2.Distance(startTouchPosition, currentTouchPosition) >= minSwipeDistance)
        {
            swipeCount++;
            //Debug.Log(swipeCount);

            targetObject.GetComponent<SpriteRenderer>().color = new Color(swipeCount / 256, swipeCount / 256, swipeCount / 256, 1);

            startTouchPosition = currentTouchPosition;
        }

        
    }
}

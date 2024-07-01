using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EngineActivate_MiniGame : MonoBehaviour
{
    public float rotationSpeed = 1.0f;  
    private List<Vector2> touchPositions = new List<Vector2>();
    private bool isRotating = false;
    private Vector2 previousDirection;
    private float currentRotationAngle = 0f;

    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                touchPositions.Clear();
                touchPositions.Add(touch.position);
                isRotating = true;
                previousDirection = Vector2.zero;
            }

            if (touch.phase == TouchPhase.Moved)
            {
                touchPositions.Add(touch.position);

                if (isRotating && touchPositions.Count > 1)
                {
                    Vector2 currentDirection = touchPositions[touchPositions.Count - 1] - touchPositions[touchPositions.Count - 2];
                    if (previousDirection != Vector2.zero)
                    {
                        float angle = Vector2.SignedAngle(previousDirection, currentDirection);
                        currentRotationAngle = Mathf.Lerp(currentRotationAngle, -angle * rotationSpeed, Time.deltaTime * 5);
                        transform.Rotate(Vector3.up, currentRotationAngle);
                    }
                    previousDirection = currentDirection;
                }
            }

            if (touch.phase == TouchPhase.Ended || touch.phase == TouchPhase.Canceled)
            {
                touchPositions.Add(touch.position);
                isRotating = false;
                previousDirection = Vector2.zero;
            }
        }
    }
}

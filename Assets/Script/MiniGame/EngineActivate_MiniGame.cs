using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EngineActivate_MiniGame : MonoBehaviour
{
    public float rotationSpeed = 0.2f;  
    private List<Vector2> touchPositions = new List<Vector2>();
    private bool isRotating = false;
    private Vector2 previousDirection;
    private float currentRotationAngle = 0f;

    private List<float> touchTimes = new List<float>();

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

                touchTimes.Clear();
                touchTimes.Add(Time.time);

            }

            if (touch.phase == TouchPhase.Moved)
            {
                touchPositions.Add(touch.position);
                touchTimes.Add(Time.time);

                if (isRotating && touchPositions.Count > 1)
                {
                    Vector2 currentDirection = touchPositions[touchPositions.Count - 1] - touchPositions[touchPositions.Count - 2];
                    if (previousDirection != Vector2.zero)
                    {
                        float currentTime = touchTimes[touchTimes.Count - 1];
                        float previousTime = touchTimes[touchTimes.Count - 2];

                        float deltaTime = currentTime - previousTime;
                        float speed = currentDirection.magnitude / deltaTime * 0.1f;

                        float angle = Vector2.SignedAngle(previousDirection, currentDirection);
                        currentRotationAngle = Mathf.Lerp(currentRotationAngle, -angle * speed, Time.deltaTime * 0.1f);

                        transform.Rotate(Vector3.up, rotationSpeed * currentRotationAngle);
                    }
                    previousDirection = currentDirection;
                }
            }

            if (touch.phase == TouchPhase.Ended || touch.phase == TouchPhase.Canceled)
            {
                touchPositions.Add(touch.position);
                touchTimes.Add(Time.time);
                isRotating = false;
                previousDirection = Vector2.zero;
            }
        }
    }

   // public Transform targetObject;  // ȸ����ų ��� ������Ʈ
   // public float rotationMultiplier = 0.1f;  // ȸ�� �ӵ� ������ ����
   //
   // private List<Vector2> touchPoints = new List<Vector2>();
   // private List<float> touchTimes = new List<float>();
   // private bool isDragging = false;
   //
   // void Update()
   // {
   //     // ��ġ �Է� ó��
   //     if (Input.touchCount > 0)
   //     {
   //         Touch touch = Input.GetTouch(0);
   //
   //         switch (touch.phase)
   //         {
   //             case TouchPhase.Began:
   //                 // ��ġ ���� ����
   //                 touchPoints.Clear();
   //                 touchTimes.Clear();
   //                 touchPoints.Add(touch.position);
   //                 touchTimes.Add(Time.time);
   //                 isDragging = true;
   //                 break;
   //
   //             case TouchPhase.Moved:
   //                 // ��ġ �̵� ����
   //                 if (isDragging)
   //                 {
   //                     touchPoints.Add(touch.position);
   //                     touchTimes.Add(Time.time);
   //                     RotateObject();
   //                 }
   //                 break;
   //
   //             case TouchPhase.Ended:
   //             case TouchPhase.Canceled:
   //                 // ��ġ ���� ����
   //                 if (isDragging)
   //                 {
   //                     touchPoints.Add(touch.position);
   //                     touchTimes.Add(Time.time);
   //                     isDragging = false;
   //                 }
   //                 break;
   //         }
   //     }
   // }
   //
   // void RotateObject()
   // {
   //     if (touchPoints.Count < 2)
   //         return;
   //
   //     // ���� ��ġ ������ ���� ��ġ ���� ���� ���� ���� ���
   //     Vector2 currentTouch = touchPoints[touchPoints.Count - 1];
   //     Vector2 previousTouch = touchPoints[touchPoints.Count - 2];
   //
   //     Vector2 direction = currentTouch - previousTouch;
   //     float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
   //
   //     // ��ġ �̵� �ð� ���
   //     float currentTime = touchTimes[touchTimes.Count - 1];
   //     float previousTime = touchTimes[touchTimes.Count - 2];
   //     float deltaTime = currentTime - previousTime;
   //
   //     // �̵� �ӵ��� ���� ȸ�� �ӵ� ���
   //     float speed = direction.magnitude / deltaTime;
   //     float rotationSpeed = speed * rotationMultiplier * 0.01f;
   //
   //     // ������Ʈ ȸ��
   //     targetObject.Rotate(Vector3.up, angle * rotationSpeed * Time.deltaTime);
   // }
}

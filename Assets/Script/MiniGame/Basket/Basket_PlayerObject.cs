using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Basket_PlayerObject : MonoBehaviour
{
    public float moveSpeed;

    private void Start()
    {
        moveSpeed = 5f;
    }
    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began || touch.phase == TouchPhase.Moved || touch.phase == TouchPhase.Stationary)
            {
                if (touch.position.x < Screen.width / 2)
                {
                    MoveLeft();
                }
                else if (touch.position.x > Screen.width / 2)
                {
                    MoveRight();
                }
            }
        }
    }

    void MoveLeft()
    {
        transform.Translate(Vector2.left * moveSpeed * Time.deltaTime);
    }

    void MoveRight()
    {
        transform.Translate(Vector2.right * moveSpeed * Time.deltaTime);
    }
}

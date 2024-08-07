using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scales_Control_Manager : MonoBehaviour
{
    public Transform leftPan; // 왼쪽 저울판 위치
    public Transform rightPan; // 오른쪽 저울판 위치
    public Rigidbody2D leftWeight; // 왼쪽 저울추
    public Rigidbody2D rightWeight; // 오른쪽 저울추

    private void Update()
    {
        float leftMoment = leftWeight.mass * (leftPan.position.x - leftWeight.position.x);
        float rightMoment = rightWeight.mass * (rightWeight.position.x - rightPan.position.x);

        float rotationAmount = leftMoment - rightMoment;

        transform.rotation = Quaternion.Euler(0, 0, rotationAmount);
    }
}

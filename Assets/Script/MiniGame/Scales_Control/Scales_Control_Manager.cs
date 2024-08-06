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
        // 저울추의 질량과 위치에 따른 회전 모멘트 계산
        float leftMoment = leftWeight.mass * (leftPan.position.x - leftWeight.position.x);
        float rightMoment = rightWeight.mass * (rightWeight.position.x - rightPan.position.x);

        // 모멘트의 차이에 따라 저울판을 기울임
        float rotationAmount = leftMoment - rightMoment;

        // 저울판에 회전 적용
        transform.rotation = Quaternion.Euler(0, 0, rotationAmount);
    }
}

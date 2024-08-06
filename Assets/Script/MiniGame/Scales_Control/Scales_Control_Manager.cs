using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scales_Control_Manager : MonoBehaviour
{
    public Transform leftPan; // ���� ������ ��ġ
    public Transform rightPan; // ������ ������ ��ġ
    public Rigidbody2D leftWeight; // ���� ������
    public Rigidbody2D rightWeight; // ������ ������

    private void Update()
    {
        // �������� ������ ��ġ�� ���� ȸ�� ���Ʈ ���
        float leftMoment = leftWeight.mass * (leftPan.position.x - leftWeight.position.x);
        float rightMoment = rightWeight.mass * (rightWeight.position.x - rightPan.position.x);

        // ���Ʈ�� ���̿� ���� �������� �����
        float rotationAmount = leftMoment - rightMoment;

        // �����ǿ� ȸ�� ����
        transform.rotation = Quaternion.Euler(0, 0, rotationAmount);
    }
}

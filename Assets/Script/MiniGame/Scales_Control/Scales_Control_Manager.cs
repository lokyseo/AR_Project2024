using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scales_Control_Manager : MonoBehaviour
{
    public GameObject leftUnder;
    public GameObject rightUnder;

    public GameObject supportStick;

    float lockPosition;

    bool isComplete;
    public float left;
    public float right;
    private void Start()
    {
        lockPosition = leftUnder.transform.position.x;
        isComplete = false;
    }

    private void Update()
    {
        left = leftUnder.GetComponent<Rigidbody2D>().mass;
        right = rightUnder.GetComponent<Rigidbody2D>().mass;

        leftUnder.transform.position = new Vector3(lockPosition, leftUnder.transform.position.y, -1);
        rightUnder.transform.position = new Vector3(-lockPosition, rightUnder.transform.position.y, -1);

        //if(supportStick.transform.rotation.z < 2 && supportStick.transform.rotation.z > 2 && isComplete)
        //{
        //
        //}
    }
}

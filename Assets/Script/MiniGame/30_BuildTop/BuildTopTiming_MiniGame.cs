using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BuildTopTiming_MiniGame : MonoBehaviour
{
    public Transform spawn_Position;
    public GameObject block_Object;
    Vector3 startPosition;

    GameObject controll_Object;
    Rigidbody2D controll_Rb;
    float moveSpeed;
    float distance;

    void Start()
    {
        controll_Object = Instantiate(block_Object, spawn_Position.position, Quaternion.identity);
        controll_Object.transform.SetParent(spawn_Position.parent);
        controll_Rb = controll_Object.GetComponent<Rigidbody2D>();
        controll_Rb.gravityScale = 0;
        startPosition = spawn_Position.position;
        moveSpeed = 3.0f;
        distance = 3;
    }

    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);


            if (touch.phase == TouchPhase.Began)
            {
                controll_Rb.gravityScale = 1;


            }


            if (touch.phase == TouchPhase.Ended)
            {
                Invoke("SpawnObject", 0.5f);
                
            }


        }
        
        if(controll_Rb.velocity.y == 0)
        {
           float offset = Mathf.PingPong(Time.time * moveSpeed, distance * 2) - distance;
           controll_Object.transform.position = spawn_Position.position + new Vector3(offset, 0, 0);
        }


    }

    void SpawnObject()
    {
        controll_Object = Instantiate(block_Object, startPosition, Quaternion.identity);
        controll_Object.transform.SetParent(spawn_Position.parent);
        controll_Rb = controll_Object.GetComponent<Rigidbody2D>();
        controll_Rb.gravityScale = 0;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunLeftRightCollision : MonoBehaviour
{
    float moveSpeed;

    void Start()
    {
        moveSpeed = 200.0f;
    }

    void Update()
    {
        transform.localPosition += Vector3.down * moveSpeed * Time.deltaTime;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.transform.tag == "Player")
        {
            Destroy(collision.gameObject);
        }

        if (collision.transform.tag == "Failed")
        {
            Destroy(gameObject);
        }
    }

}

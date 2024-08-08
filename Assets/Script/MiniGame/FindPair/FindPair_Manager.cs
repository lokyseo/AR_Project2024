using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindPair_Manager : MonoBehaviour
{
    public float zoomSpeed = 1f; 
    public Vector3 maxScale = new Vector3(3f, 3f, 1f);
    float speed;
    void Start()
    {
        speed = 2.5f;
    }

    void Update()
    {
        Vector3 currentScale = transform.localScale;

        if (currentScale.x < maxScale.x)
        {
            transform.localScale += Vector3.one * zoomSpeed * Time.deltaTime;
        }

        transform.Translate(Vector3.down * speed * Time.deltaTime);
    }
}

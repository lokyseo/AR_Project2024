using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dots_Property : MonoBehaviour
{
    public GameObject[] nearDots;
    public LineRenderer lineRenderer;
    public int connectComplete = 0;
    public bool isFailed;
    void Start()
    {
        isFailed = false;
    }

    void Update()
    {
        connectComplete = 0;

        for (int i = 0; i < lineRenderer.positionCount - 1; i++)
        {
            Vector3 start = lineRenderer.GetPosition(i);
            Vector3 end = lineRenderer.GetPosition(i + 1);

            for (int j = 0; j < nearDots.Length; j++)
            {
                if ((transform.position == start && nearDots[j].transform.position == end) ||
                    (transform.position == end && nearDots[j].transform.position == start))
                {
                    connectComplete++;
                }
            }

        }

        if (connectComplete >= nearDots.Length)
        {
            this.GetComponent<CircleCollider2D>().enabled = false;
            this.GetComponent<SpriteRenderer>().color = Color.red;
        }



        if(isFailed)
        {
            FailedConnect();
            isFailed = false;
        }
    }

    void FailedConnect()
    {
        this.GetComponent<CircleCollider2D>().enabled = true;
        this.GetComponent<SpriteRenderer>().color = Color.black;
    }
}

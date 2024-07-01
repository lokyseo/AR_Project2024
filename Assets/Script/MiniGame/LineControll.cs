using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LineControll : MonoBehaviour
{
    LineRenderer lineRenderer;
    Vector3[] linePosition = new Vector3[2];
    public bool test;

    void Start()
    {
        
        //lineRenderer.material.color = GetComponentInParent<Image>().color;
        //lineRenderer.positionCount = linePosition.Length;
    }

    void Update()
    {
        if (Input.touchCount > 0)
        {
            if (test) return;

            Touch touch = Input.GetTouch(0);
            Ray ray = Camera.main.ScreenPointToRay(touch.position);
            RaycastHit hit;

            if (touch.phase == TouchPhase.Began)
            {

            }

            if (touch.phase == TouchPhase.Moved)
            {
                
            }

            if (touch.phase == TouchPhase.Ended)
            {
                if(Physics.Raycast(ray, out hit))
                {
                    if(hit.collider.gameObject != this.gameObject && hit.transform.tag == "LineConnect")
                    {
                        lineRenderer.enabled = true;
                        linePosition[1] = hit.collider.transform.position;
                        lineRenderer.SetPositions(linePosition);
                    }
                    else
                    {
                        lineRenderer.enabled = false;
                    }
                    Debug.Log(hit.collider.gameObject);
                }
            }
        }
    }
}

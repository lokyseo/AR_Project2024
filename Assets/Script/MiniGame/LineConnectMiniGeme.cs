using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class LineConnectMiniGeme : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler
{
    public GameObject lineImg;
    private Vector3 startPos;

    GameObject clicked_Object;
    LineRenderer lineRenderer;
    Vector3[] linePosition = new Vector3[2];

    public void OnPointerDown(PointerEventData eventData)
    {
        clicked_Object = eventData.pointerCurrentRaycast.gameObject;
        lineRenderer = clicked_Object.GetComponentInChildren<LineRenderer>();
        linePosition[1] = linePosition[0];
        lineRenderer.SetPositions(linePosition);

        lineRenderer.enabled = true;
        lineRenderer.material.color = clicked_Object.GetComponent<Image>().color;

        lineRenderer.positionCount = linePosition.Length;

        linePosition[0] = clicked_Object.transform.position;
    }

    public void OnDrag(PointerEventData eventData)
    {
        //linePosition[0] = clicked_Object.transform.position;

        linePosition[1] = Camera.main.ScreenToWorldPoint(eventData.position);
        lineRenderer.SetPositions(linePosition);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if (eventData.pointerCurrentRaycast.gameObject == null)
        {
            lineRenderer.enabled = false;
            return;
        }
        else if(eventData.pointerCurrentRaycast.gameObject.tag == "LineConnect" &&
            eventData.pointerCurrentRaycast.gameObject.GetComponent<Image>().color == lineRenderer.material.color)
        {
            linePosition[1] = eventData.pointerCurrentRaycast.gameObject.transform.position;
            lineRenderer.SetPositions(linePosition);
            //lineRenderer.test = true;
        }
        else
        {
            lineRenderer.enabled = false;
        }

    }


    void Start()
    {

    }

    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            


            if (touch.phase == TouchPhase.Began)
            {
                
            }

            if (touch.phase == TouchPhase.Moved)
            {

            }

            if (touch.phase == TouchPhase.Ended)
            {

            }
        }

    }


}


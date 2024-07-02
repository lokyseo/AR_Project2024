using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class LineConnectMiniGeme : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler
{
    public GameObject lineImg;
    private Vector3 startPos;

    GameObject clicked_Object;
    LineRenderer lineRenderer;
    Vector3[] linePosition = new Vector3[2];
    int connectCount;
    bool isSameColor;

    private void Awake()
    {
        isSameColor = false;
        connectCount = 0;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        clicked_Object = eventData.pointerCurrentRaycast.gameObject;
        lineRenderer = clicked_Object.GetComponentInChildren<LineRenderer>();
        linePosition[1] = linePosition[0];
        lineRenderer.SetPositions(linePosition);

        if(lineRenderer.enabled)
        {
            isSameColor = true;
        }
        else
        {
            isSameColor = false;
            lineRenderer.enabled = true;
            
        }
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

            if(!isSameColor)
            {
                connectCount++;
                if(connectCount == 4)
                {
                    SceneManager.LoadScene("MainScene");
                }
            }
            //lineRenderer.test = true;
        }
        else
        {
            lineRenderer.enabled = false;
        }

    }


}


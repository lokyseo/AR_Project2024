using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using System.Linq;

public class LineConnectMiniGeme : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler
{
    public GameObject lineImg;
    private Vector3 startPos;

    GameObject clicked_Object;
    LineRenderer lineRenderer;
    Vector3[] linePosition = new Vector3[2];
    public int connectCount;

    public Image[] left_Image;
    public Image[] right_Image;

    bool isSameColor;

    private void Awake()
    {
        isSameColor = false;
        connectCount = 0;

        ResetColor();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        clicked_Object = eventData.pointerCurrentRaycast.gameObject;
        lineRenderer = clicked_Object.GetComponentInChildren<LineRenderer>();

        linePosition[0] = clicked_Object.transform.position;
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
            linePosition[0] = clicked_Object.transform.position;
            linePosition[1] = linePosition[0];
            lineRenderer.SetPositions(linePosition);
            lineRenderer.enabled = false;
            return;
        }
        else if(eventData.pointerCurrentRaycast.gameObject.tag == "LineConnect" &&
            eventData.pointerCurrentRaycast.gameObject.GetComponent<Image>().color == lineRenderer.material.color)
        {
            linePosition[1] = eventData.pointerCurrentRaycast.gameObject.transform.position;
            lineRenderer.SetPositions(linePosition);
            
            

            if(!isSameColor && !eventData.pointerCurrentRaycast.gameObject.GetComponentInChildren<LineRenderer>().enabled)
            {
                connectCount++;
                eventData.pointerCurrentRaycast.gameObject.GetComponentInChildren<LineRenderer>().enabled = true;
                if (connectCount == 4)
                {
                    SceneManager.LoadScene("MainScene");
                }
            }
            
            //lineRenderer.test = true;
        }
        else
        {
            linePosition[0] = clicked_Object.transform.position;
            linePosition[1] = linePosition[0];
            lineRenderer.SetPositions(linePosition);
            lineRenderer.enabled = false;
        }

    }

    private void ResetColor()
    {
        int[] color_Array = new int[4];
        int randNum;

        for (int j = 0; j < 2; j++)
        {
            for (int i = 0; i < color_Array.Length; i++)
            {
                color_Array[i] = 4;

            }
            for (int i = 0; i < 4;)
            {
                randNum = Random.Range(0, 4);

                if (color_Array.Contains(randNum))
                {
                    continue;
                }
                else
                {
                    color_Array[i] = randNum;
                    switch (randNum)
                    {
                        case 0:
                            if (j == 0)
                            {
                                left_Image[i].color = Color.red;
                            }
                            else
                            {
                                right_Image[i].color = Color.red;
                            }
                            break;
                        case 1:
                            if (j == 0)
                            {
                                left_Image[i].color = Color.blue;
                            }
                            else
                            {
                                right_Image[i].color = Color.blue;
                            }
                            break;
                        case 2:
                            if (j == 0)
                            {
                                left_Image[i].color = Color.yellow;
                            }
                            else
                            {
                                right_Image[i].color = Color.yellow;
                            }
                            break;
                        case 3:
                            if (j == 0)
                            {
                                left_Image[i].color = Color.green;
                            }
                            else
                            {
                                right_Image[i].color = Color.green;
                            }
                            break;
                    }

                    i++;
                }

            }
        }
    }
}


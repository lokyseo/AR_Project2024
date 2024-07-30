using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using System.Linq;
using TMPro;
using UnityEditor;

public class LineConnectMiniGeme : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler
{
    public GameObject lineImg;
    private Vector3 startPos;

    GameObject clicked_Object;
    LineRenderer lineRenderer;
    Vector3[] linePosition = new Vector3[2];
    public bool[] isConnect = new bool[4];

    public Image[] left_Image;
    public Image[] right_Image;

    public Sprite[] left_Sprite;
    public Sprite[] right_Sprite;

    public TextMeshProUGUI time_Text;
    float clearTime;

    private void Awake()
    {
        for(int i = 0; i < isConnect.Length; i++)
        {
            isConnect[i] = false;
        }
        clearTime = 10.0f;
        ResetColor();
    }
    void Update()
    {
        clearTime -= Time.deltaTime;
        time_Text.text = clearTime.ToString("F1");

        if(clearTime < 0)
        {
            time_Text.text = "0.0";
            SceneManager.LoadScene("MainScene");
        }
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        clicked_Object = eventData.pointerCurrentRaycast.gameObject;
        lineRenderer = clicked_Object.GetComponentInChildren<LineRenderer>();

        linePosition[0] = clicked_Object.transform.position;
        linePosition[1] = linePosition[0];
        lineRenderer.SetPositions(linePosition);

        lineRenderer.enabled = true;

       
        switch (clicked_Object.tag)
        {
            case "Red":
                lineRenderer.material.color = Color.red;
                //lineRenderer.startColor = Color.red;
                //lineRenderer.endColor = Color.red;
                break;
            case "Blue":
                lineRenderer.material.color = Color.blue;
                break ;
            case "Yellow":
                lineRenderer.material.color = Color.yellow;
                break;
            case "Green":
                lineRenderer.material.color = Color.green;
                break;
        }

        lineRenderer.tag = clicked_Object.tag;

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
        else if (eventData.pointerCurrentRaycast.gameObject.tag == lineRenderer.tag)
        {
            linePosition[1] = eventData.pointerCurrentRaycast.gameObject.transform.position;
            lineRenderer.SetPositions(linePosition);

            clicked_Object.GetComponent<Image>().raycastTarget = false;
            eventData.pointerCurrentRaycast.gameObject.GetComponent<Image>().raycastTarget = false;

            int connectCount = 0;

            if (lineRenderer.tag == "Red")
            {
                isConnect[0] = true;
            }
            else if (lineRenderer.tag == "Blue")
            {
                isConnect[1] = true;
            }
            else if (lineRenderer.tag == "Yellow")
            {
                isConnect[2] = true;
            }
            else if (lineRenderer.tag == "Green")
            {
                isConnect[3] = true;
            }

            for (int i = 0; i < isConnect.Length; i++)
            {
                if (isConnect[i])
                {
                    connectCount++;
                }
            }
            if (connectCount == 4)
            {
                SceneManager.LoadScene("MainScene");
            }


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
                                left_Image[i].sprite = left_Sprite[randNum];
                                left_Image[i].tag = "Red";
                            }
                            else
                            {
                                right_Image[i].tag = "Red";
                                right_Image[i].sprite = right_Sprite[randNum];
                            }
                            break;
                        case 1:
                            if (j == 0)
                            {
                                left_Image[i].tag = "Blue";
                                left_Image[i].sprite = left_Sprite[randNum];
                            }
                            else
                            {
                                right_Image[i].tag = "Blue";
                                right_Image[i].sprite = right_Sprite[randNum];
                            }
                            break;
                        case 2:
                            if (j == 0)
                            {
                                left_Image[i].tag = "Yellow";
                                left_Image[i].sprite = left_Sprite[randNum];
                            }
                            else
                            {
                                right_Image[i].tag = "Yellow";
                                right_Image[i].sprite = right_Sprite[randNum];
                            }
                            break;
                        case 3:
                            if (j == 0)
                            {
                                left_Image[i].tag = "Green";
                                left_Image[i].sprite = left_Sprite[randNum];
                            }
                            else
                            {
                                right_Image[i].tag = "Green";
                                right_Image[i].sprite = right_Sprite[randNum];
                            }
                            break;
                    }

                    i++;
                }

            }
        }
    }
}


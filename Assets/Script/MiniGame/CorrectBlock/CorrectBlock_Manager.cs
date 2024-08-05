using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class CorrectBlock_Manager : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler
{
    GameObject clicked_Object;
    public GameObject totalGround_Object;
    Vector3 startPos;

    public int countBool;

    Vector3 lastMousePosition;


    void Start()
    {

    }

    void Update()
    {

    }

    public void OnPointerDown(PointerEventData eventData)
    {
        clicked_Object = eventData.pointerCurrentRaycast.gameObject.transform.parent.gameObject;
        if (clicked_Object.tag != "Ground")
        {
            startPos = clicked_Object.transform.position;
            for (int i = 0; i < clicked_Object.transform.childCount; i++)
            {
                clicked_Object.transform.GetChild(i).GetComponent<Image>().raycastTarget = false;

            }

            clicked_Object.transform.position = Camera.main.ScreenToWorldPoint(new Vector3(eventData.position.x, eventData.position.y, startPos.z));
        }
        else
        {
            clicked_Object = null;
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (clicked_Object != null)
        {
            //Vector3 currentMousePosition = Input.mousePosition;
            //Vector3 mouseDelta = currentMousePosition - lastMousePosition;
            //clicked_Object.GetComponent<RectTransform>().anchoredPosition += new Vector2(mouseDelta.x, mouseDelta.y);
            //lastMousePosition = currentMousePosition;
            clicked_Object.transform.position = Camera.main.ScreenToWorldPoint(new Vector3(eventData.position.x, eventData.position.y, startPos.z));
        }
    }
    
    public void OnPointerUp(PointerEventData eventData)
    {
        if (clicked_Object != null)
        {
            GameObject upPoint_Object = eventData.pointerCurrentRaycast.gameObject;
            if (upPoint_Object != null)
            {
                if (upPoint_Object.tag == "Ground")
                {
                    bool[] isOverLapping = new bool[clicked_Object.transform.childCount];
                    for (int i = 0; i < clicked_Object.transform.GetComponentsInChildren<BoxCollider2D>().Length; i++)
                    {
                        isOverLapping[i] = false;
                        Collider2D[] colliders = Physics2D.OverlapBoxAll(clicked_Object.transform.GetChild(i).position,
                            new Vector2(0.5f,0.5f), 0f);

                        foreach (Collider2D collider in colliders)
                        {
                            if(collider.gameObject != clicked_Object.transform.GetChild(i).gameObject)
                            {
                                Debug.Log(collider.gameObject.name);

                                if (collider.gameObject.tag == "Ground")
                                {
                                    isOverLapping[i] = true;
                                }
                                if (collider.gameObject.tag == "Block")
                                {
                                    Debug.Log("ÀÚ¸®¿ä");
                                    isOverLapping[i] = false;
                                    break;
                                }
                            }
                          
                        }
                    }

                    countBool = 0;
                    for (int i = 0; i < clicked_Object.transform.GetComponentsInChildren<BoxCollider2D>().Length; i++)
                    {
                        if (!isOverLapping[i])
                        {
                            clicked_Object.transform.position = startPos;
                            break;
                        }
                        else
                        {
                            countBool++;
                        }
                    }
                    if(countBool == clicked_Object.transform.GetComponentsInChildren<BoxCollider2D>().Length)
                    {
                        clicked_Object.transform.position = upPoint_Object.transform.position;
                    }

                }
                else if(upPoint_Object.tag == "Block")
                {
                    clicked_Object.transform.position = startPos;
                }
            }
            for (int i = 0; i < clicked_Object.transform.childCount; i++)
            {
                clicked_Object.GetComponentsInChildren<Image>()[i].raycastTarget = true;
            }
           
        }
    }
}

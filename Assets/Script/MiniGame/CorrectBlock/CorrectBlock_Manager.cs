using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class CorrectBlock_Manager : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler
{
    GameObject clicked_Object;

    Vector3 startPos;

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
            Debug.Log(clicked_Object.name);
        }
        else
        {
            clicked_Object = null;
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        if(clicked_Object != null)
        {
            clicked_Object.transform.position = Camera.main.ScreenToWorldPoint(new Vector3(eventData.position.x, eventData.position.y, startPos.z));

        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if (clicked_Object != null)
        {
           
        }
    }
    
}

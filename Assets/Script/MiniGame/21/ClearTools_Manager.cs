using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ClearTools_Manager : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler
{
    GameObject clicked_Object;
    float startZ;
    public GameObject Dummy;

    private void Awake()
    {
        
    }
    void Update()
    {
        if (Dummy.transform.childCount <= 0)
        {
            SceneManager.LoadScene("MainScene");
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (eventData.pointerCurrentRaycast.gameObject.tag == "Block")
        {
            clicked_Object = eventData.pointerCurrentRaycast.gameObject;
            clicked_Object.GetComponent<Image>().raycastTarget = false;
            startZ = clicked_Object.transform.position.z;
        }

    }

    public void OnDrag(PointerEventData eventData)
    {
        if (clicked_Object != null)
        {
            clicked_Object.transform.position = Camera.main.ScreenToWorldPoint(new Vector3(eventData.position.x, eventData.position.y, startZ));

        }

    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if (clicked_Object != null)
        {
            if (eventData.pointerCurrentRaycast.gameObject != null && eventData.pointerCurrentRaycast.gameObject.tag == "Container")
            {
                Image clicked_Image = clicked_Object.GetComponent<Image>();
                Image event_Image = eventData.pointerCurrentRaycast.gameObject.GetComponent<Image>();
                if (clicked_Image.sprite == event_Image.sprite)
                {
                    Destroy(clicked_Object);
                    
                }
            }

            clicked_Object.GetComponent<Image>().raycastTarget = true;
            clicked_Object = null;

           
        }
    }
}

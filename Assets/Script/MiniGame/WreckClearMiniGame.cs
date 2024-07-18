using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class WreckClearMiniGame : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler
{
    GameObject clicked_Object;
    float startZ;
    private void Awake()
    {
        
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        clicked_Object = eventData.pointerCurrentRaycast.gameObject;
        startZ = clicked_Object.transform.position.z;
    }

    public void OnDrag(PointerEventData eventData)
    {
        clicked_Object.transform.position = Camera.main.ScreenToWorldPoint(new Vector3(eventData.position.x, eventData.position.y, startZ));
        
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        //clicked_Object.transform.position = new Vector3(clicked_Object.transform.position.x, clicked_Object.transform.position.y, 0);

    }

   
}

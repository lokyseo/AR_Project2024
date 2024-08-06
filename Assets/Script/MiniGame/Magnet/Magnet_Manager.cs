using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class Magnet_Manager : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler
{
    GameObject clicked_Object;
    Vector3 lastMousePosition;

    public float magneticForce;
    public float magneticRange;

    void Start()
    {
        magneticForce = 100.0f;
        magneticRange = 3.0f;    
    }

    void Update()
    {
        
    }
   

    public void OnPointerDown(PointerEventData eventData)
    {
        if(eventData.pointerCurrentRaycast.gameObject.tag == "Magnet")
        {
            clicked_Object = eventData.pointerCurrentRaycast.gameObject.transform.parent.gameObject;

            lastMousePosition = Input.mousePosition;
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
            Vector3 currentMousePosition = Input.mousePosition;
            Vector3 mouseDelta = currentMousePosition - lastMousePosition;
            clicked_Object.GetComponent<RectTransform>().anchoredPosition += new Vector2(mouseDelta.x, mouseDelta.y);
            lastMousePosition = currentMousePosition;
            //clicked_Object.transform.position = Camera.main.ScreenToWorldPoint(new Vector3(eventData.position.x, eventData.position.y, startPos.z));
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if (clicked_Object != null)
        {
           

        }
    }
    void OnDrawGizmosSelected()
    {
        // 자석의 영향을 시각적으로 확인하기 위한 범위 표시
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, magneticRange);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        Rigidbody2D rb = collision.attachedRigidbody;
        if (rb != null)
        {
            Vector3 direction = transform.position - collision.transform.position;
            float distance = direction.magnitude;

            if (distance < magneticRange)
            {
                float forceMagnitude = magneticForce / distance; // 거리에 반비례하여 힘 증가
                rb.AddForce(direction.normalized * forceMagnitude);
            }
        }
    }
}

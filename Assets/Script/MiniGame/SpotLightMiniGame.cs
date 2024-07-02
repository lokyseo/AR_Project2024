using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.SceneManagement;

public class SpotLightMiniGame : MonoBehaviour
{
    public Light2D spotLight; 
    float detectionDistance;
    public LayerMask detectionLayer;
    float timeCount;

    void Start()
    {
        timeCount = 0;
        detectionDistance = 100.0f;
    }
    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.forward, detectionDistance, detectionLayer);
            Debug.DrawRay(transform.position, transform.forward, Color.red, 100f);

            if (hit.collider != null)
            {
                OnObjectDetected(hit.collider.gameObject);
            }
            if (touch.phase == TouchPhase.Began)
            {
                
            }

            if (touch.phase == TouchPhase.Moved)
            {
                this.transform.position = Camera.main.ScreenToWorldPoint(new Vector3(touch.position.x, touch.position.y, transform.position.z));
                
            }

        }
        

    }

    void OnObjectDetected(GameObject detectedObject)
    {
        if(detectedObject.tag == "Card")
        {
            timeCount += Time.deltaTime;
            if(timeCount > 1.5f)
            {
                detectedObject.GetComponent<SpriteRenderer>().color = Color.red;
                SceneManager.LoadScene("MainScene");

            }

        }
    }
}

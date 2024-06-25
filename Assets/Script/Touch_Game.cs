using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Touch_Game : MonoBehaviour
{
    void Start()
    {

    }

    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            Ray ray = Camera.main.ScreenPointToRay(touch.position);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform.tag == "Explode_Sphere")
                {
                    Destroy(hit.transform.gameObject);
                }
            }

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

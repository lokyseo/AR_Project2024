using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WoodRollMiniGame : MonoBehaviour
{
    public GameObject wood_Object;
    GameObject player_Object;
    void Start()
    {
        player_Object = GameObject.FindWithTag("Player");
    }

    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            Ray ray = Camera.main.ScreenPointToRay(touch.position);
            RaycastHit hit;

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

        wood_Object.transform.Rotate(Vector3.forward, 20.0f * Time.deltaTime);
    }
}

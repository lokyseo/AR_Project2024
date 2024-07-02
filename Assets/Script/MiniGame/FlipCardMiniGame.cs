using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FlipCardMiniGame : MonoBehaviour
{
    SpriteRenderer[] checked_Sprite = new SpriteRenderer[2];
    GameObject[] clicked_Object = new GameObject[2];
    public int touchCount;
    string checked_Same;
    bool touchBlocked;

    void Start()
    {
        touchCount = 0;
        touchBlocked = false;
    }

    void Update()
    {
        if (touchCount >= 2)
        {
            touchBlocked = true;
            if (clicked_Object[1].transform.eulerAngles.y >= 350)
            {
                touchBlocked = false;

                if (checked_Sprite[0].sprite == checked_Sprite[1].sprite)
                {
                    for(int i = 0; i < clicked_Object.Length; i++)
                    {
                        clicked_Object[i].GetComponent<BoxCollider>().enabled = false;
                    }
                    for(int i = 0; i < gameObject.transform.childCount; i++)
                    {
                        if(gameObject.GetComponentsInChildren<BoxCollider>()[i].enabled)
                        {
                            break;
                        }
                        if(i == gameObject.transform.childCount -1)
                        {
                            SceneManager.LoadScene("MainScene");
                        }
                    }

                }
                else
                {
                    for (int i = 0; i < clicked_Object.Length; i++)
                    {
                        clicked_Object[i].GetComponent<FlipCard>().isTouched = false;
                    }

                }

                touchCount = 0;
            }
           
        }

        if (Input.touchCount > 0 && !touchBlocked)
        {
            Touch touch = Input.GetTouch(0);
            
            Ray ray = Camera.main.ScreenPointToRay(touch.position);
            RaycastHit hit;


            if (touch.phase == TouchPhase.Began)
            {
                if (Physics.Raycast(ray, out hit))
                {
                    if (hit.collider.tag == "Card")
                    {
                        checked_Same = hit.collider.gameObject.name;


                    }
                }
            }


            if (touch.phase == TouchPhase.Ended)
            {
                if (Physics.Raycast(ray, out hit))
                {
                    if (hit.collider.tag == "Card" && checked_Same == hit.collider.gameObject.name)
                    {
                        hit.collider.GetComponent<FlipCard>().isTouched = true;
                        clicked_Object[touchCount] = hit.collider.gameObject;
                        checked_Sprite[touchCount] = hit.collider.GetComponentInChildren<SpriteRenderer>();
                        touchCount++;
                        
                    }
                }
                
            }

        }
       
    }

}

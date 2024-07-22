using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FlipCardMiniGame : MonoBehaviour
{
    SpriteRenderer[] checked_Sprite = new SpriteRenderer[2];
    GameObject[] clicked_Object = new GameObject[2];
    public int touchCount;
    string checked_Same;
    bool touchBlocked;

    public Sprite[] sprite_Source;
    public GameObject totalCard;

    public TextMeshProUGUI time_Text;
    float clearTime;

    void Start()
    {
        touchCount = 0;
        touchBlocked = false;

        clearTime = 30.0f;

        RandomCard();

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


    void RandomCard()
    {
        int[] count_array = new int[10];
        for (int i = 0; i < count_array.Length; i++)
        {
            count_array[i] = 0;
        }

       
        for(int i = 0; i < 5; i++)
        {
            for(int j = 0; j < 2;)
            {
                int firstRand = Random.Range(0, 10);

                if (count_array[firstRand] == 1)
                {

                }
                else
                {
                    totalCard.transform.GetChild(firstRand).GetComponentInChildren<SpriteRenderer>().sprite = sprite_Source[i];
                    count_array[firstRand] = 1;
                    j++;
                }
                
            }
            
        }
        

        
    }
}

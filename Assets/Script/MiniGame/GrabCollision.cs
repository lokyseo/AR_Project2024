using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GrabCollision : MonoBehaviour
{
    public Image[] player_Health;
    int count_Health;
    Vector3 startPosition;


    public GameObject hand_Object;
    public Sprite handImage_Defalt;
    public Sprite handImage_Grap;
    public Image count_Image;

    float judgeTime;

    void Start()
    {
        startPosition = transform.position;

        judgeTime = 0;

        this.GetComponent<Rigidbody2D>().gravityScale = 0;
        hand_Object.GetComponentInChildren<Image>().sprite = handImage_Defalt;
        hand_Object.GetComponent<CircleCollider2D>().enabled = false;

        StartCoroutine(CountNumber());
    }

    void Update()
    {
        if (!player_Health[2].gameObject.activeSelf)
        {
            SceneManager.LoadScene("MainScene");
        }

        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                if(hand_Object.GetComponentInChildren<Image>().sprite == handImage_Defalt)
                {
                    hand_Object.GetComponent<CircleCollider2D>().enabled = true;
                    hand_Object.GetComponentInChildren<Image>().sprite = handImage_Grap;
                }
                
            }

        }

        if (hand_Object.GetComponent<CircleCollider2D>().enabled)
        {
            judgeTime += Time.deltaTime;
            if (judgeTime > 0.1f)
            {
                hand_Object.GetComponent<CircleCollider2D>().enabled = false;
                judgeTime = 0;
            }

        }
    }

    IEnumerator CountNumber()
    {
        count_Image.GetComponentInChildren<Text>().text = "3";
        yield return new WaitForSeconds(1.0f);
        count_Image.GetComponentInChildren<Text>().text = "2";
        yield return new WaitForSeconds(1.0f);
        count_Image.GetComponentInChildren<Text>().text = "1";
        yield return new WaitForSeconds(1.0f);
        count_Image.gameObject.SetActive(false);

        float rand_num = Random.Range(0.1f, 2.0f);
        yield return new WaitForSeconds(rand_num);

        this.GetComponent<Rigidbody2D>().gravityScale = 2;

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Failed")
        {
            player_Health[count_Health].gameObject.SetActive(false);
            count_Health++;

            this.GetComponent<Rigidbody2D>().gravityScale = 0;
            this.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
            transform.position = startPosition;

            judgeTime = 0;
            hand_Object.GetComponent<CircleCollider2D>().enabled = false;
            hand_Object.GetComponentInChildren<Image>().sprite = handImage_Defalt;

            count_Image.gameObject.SetActive(true);
            StartCoroutine(CountNumber());
        }


        if(collision.name == "Hand")
        {
            PlayerPrefs.SetInt("MiniGame5Clear", 1);
            SceneManager.LoadScene("MainScene");
        }
    }
}

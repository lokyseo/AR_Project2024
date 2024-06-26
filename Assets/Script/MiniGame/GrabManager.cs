using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GrabManager : MonoBehaviour
{
    public GameObject hand_Object;
    public GameObject stick_Object;
    public Image count_Image;

    float judgeTime;

    void Start()
    {
        judgeTime = 0;

        stick_Object.GetComponent<Rigidbody2D>().gravityScale = 0;
        hand_Object.GetComponent<CircleCollider2D>().enabled = false;

        StartCoroutine(CountNumber());
    }

    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                hand_Object.GetComponent<CircleCollider2D>().enabled = true;
            }

        }

        if (hand_Object.GetComponent<CircleCollider2D>().enabled)
        {
            judgeTime += Time.deltaTime;
            if(judgeTime > 0.2f)
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

        stick_Object.GetComponent<Rigidbody2D>().gravityScale = 2;

    }
}

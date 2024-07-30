using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MoveToSignal_Manager : MonoBehaviour
{
    GameObject player_Object;
    public Image signal_Image;
    bool isColorRed;
    float moveSpeed;

    float durationTime;
    void Start()
    {
        player_Object = GameObject.FindWithTag("Player");
        signal_Image.color = Color.green;
        isColorRed = false;
        durationTime = 2.0f;
        moveSpeed = 2.0f;
    }

    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                moveSpeed = 0;

            }

            if (touch.phase == TouchPhase.Moved || touch.phase == TouchPhase.Stationary)
            {
                moveSpeed = 0;

            }
            if (touch.phase == TouchPhase.Ended)
            {
                moveSpeed = 2.0f;

            }

        }

        player_Object.transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);


        if(isColorRed)
        {
            durationTime -= Time.deltaTime;
            if(durationTime < 0 )
            {
                StartCoroutine(ChangeColor());
            }

            if (moveSpeed > 0)
            {
                Debug.Log("ав╬Н╤С");
            }
        }
        else
        {
            durationTime -= Time.deltaTime;
            if (durationTime < 0)
            {
                StartCoroutine(ChangeColor());
            }
        }
    }

    IEnumerator ChangeColor()
    {
        durationTime = 100;
        signal_Image.color = Color.yellow;
        yield return new WaitForSeconds(0.5f);
        int randnum = Random.Range(0, 9);

        if (randnum < 4)
        {
            isColorRed = false;
            signal_Image.color = Color.green;

        }
        else
        {
            isColorRed = true;
            signal_Image.color = Color.red;

        }
        durationTime = Random.Range(1.5f, 4.0f);
    }
}
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class JumpKingManager : MonoBehaviour
{
    public Slider powerGauge_slider;
    
    Rigidbody2D player_rigid;

    float jumpPower;
    bool isGround;

    public Image[] player_Health;
    int count_Health;
    Vector3 startPosition;
    void Start()
    {
        Application.targetFrameRate = 60;
        startPosition = transform.position;
        jumpPower = 0;
        isGround = true;

        powerGauge_slider.maxValue = 200;
        powerGauge_slider.value = jumpPower;

        player_rigid = this.GetComponent<Rigidbody2D>();
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

            }

            if(touch.phase == TouchPhase.Stationary || touch.phase == TouchPhase.Moved)
            {
                if(isGround)
                {
                    powerGauge_slider.value += 2;

                }
            }


            if (touch.phase == TouchPhase.Ended)
            {
                if (isGround)
                {
                    player_rigid.AddForce(Vector3.up * powerGauge_slider.value * 5);
                    powerGauge_slider.value = 0;
                }


            }

        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Goal")
        {
            //PlayerPrefs.SetInt("MiniGame2Clear", 1);
            SceneManager.LoadScene("MainScene");
        }

        if (collision.gameObject.tag == "Failed")
        {
            player_Health[count_Health].gameObject.SetActive(false);
            count_Health++;
            transform.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            transform.position = startPosition;

        }

        if (collision.transform.tag == "Ground")
        {
            isGround = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.transform.tag == "Ground")
        {
            isGround = false;
        }
    }

}

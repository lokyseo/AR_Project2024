using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class JumpKingManager : MonoBehaviour
{
    public Slider powerGauge_slider;
    
    Rigidbody2D player_rigid;

    float jumpPower;
    bool isGround;
    void Start()
    {
        Application.targetFrameRate = 60;

        jumpPower = 0;
        isGround = true;

        powerGauge_slider.maxValue = 200;
        powerGauge_slider.value = jumpPower;

        player_rigid = this.GetComponent<Rigidbody>();
    }

    void Update()
    {
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

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Goal")
        {
            PlayerPrefs.SetInt("MiniGame2Clear", 1);
            SceneManager.LoadScene("MainScene");
        }

        if (collision.gameObject.tag == "Failed")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);

        }

        if (collision.transform.tag == "Ground")
        {
            isGround = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.transform.tag == "Ground")
        {
            isGround = false;
        }
    }
}

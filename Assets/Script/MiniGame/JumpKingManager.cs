using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class JumpKingManager : MonoBehaviour
{
    public Slider powerGauge_slider;
    //public GameObject player_object;
    Rigidbody player_rigid;

    float jumpPower;

    void Start()
    {
        jumpPower = 0;

        powerGauge_slider.maxValue = 200;
        powerGauge_slider.value = jumpPower;

        player_rigid = GameObject.FindWithTag("Player").GetComponent<Rigidbody>();
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
                powerGauge_slider.value++;
            }


            if (touch.phase == TouchPhase.Ended)
            {
                player_rigid.AddForce(Vector3.up * powerGauge_slider.value * 5);
                powerGauge_slider.value = 0;


            }

        }
    }
}

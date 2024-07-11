using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RunLeftRight_Player : MonoBehaviour
{
    public Slider chase_Slider;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Trap")
        {
            Debug.Log("trigger");
            chase_Slider.value += 1;
            if(chase_Slider.value >= chase_Slider.maxValue)
            {
                SceneManager.LoadScene("MainScene");
            }
        }
    }
}

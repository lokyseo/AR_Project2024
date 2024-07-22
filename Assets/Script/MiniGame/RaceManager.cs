using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RaceManager : MonoBehaviour
{
    public GameObject player_Object;
    public GameObject goal_Object;

    bool isLeftButton;


    float clearTime;
    public TextMeshProUGUI time_Text;

    void Start()
    {
        clearTime = 10.0f;
    }

    void Update()
    {
        clearTime -= Time.deltaTime;
        time_Text.text = clearTime.ToString("F1");

        if (clearTime < 0)
        {
            time_Text.text = "0.0";
            SceneManager.LoadScene("MainScene");
        }


        if (player_Object.transform.localPosition.y > goal_Object.transform.localPosition.y)
        {
            PlayerPrefs.SetInt("MiniGame6Clear", 1);
            SceneManager.LoadScene("MainScene");
        }
    }

    public void LeftButton()
    {
        if(isLeftButton)
        {
            player_Object.transform.localPosition += Vector3.up * 15;
            isLeftButton = false;
        }
    }

    public void RightButton()
    {
        if (!isLeftButton)
        {
            player_Object.transform.localPosition += Vector3.up * 15;
            isLeftButton = true;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RaceManager : MonoBehaviour
{
    public GameObject player_Object;
    public GameObject goal_Object;

    bool isLeftButton;
    void Start()
    {

    }

    void Update()
    {
        if(player_Object.transform.localPosition.y > goal_Object.transform.localPosition.y)
        {
            PlayerPrefs.SetInt("MiniGame6Clear", 1);
            SceneManager.LoadScene("MainScene");
        }
    }

    public void LeftButton()
    {
        if(isLeftButton)
        {
            player_Object.transform.localPosition += Vector3.up * 10;
            isLeftButton = false;
        }
    }

    public void RightButton()
    {
        if (!isLeftButton)
        {
            player_Object.transform.localPosition += Vector3.up * 10;
            isLeftButton = true;
        }
    }
}

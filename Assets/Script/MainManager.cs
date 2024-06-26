using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainManager : MonoBehaviour
{
    public Image[] checkedClear_ImageArray;
    public GameObject panel_Object;
    
    void Start()
    {
        for(int i = 0; i < checkedClear_ImageArray.Length; i++)
        {
            if (PlayerPrefs.GetInt("MiniGame" + (i + 1) + "Clear", 0) != 0)
            {
                checkedClear_ImageArray[i].color = Color.green;
            }
            else
            {
                checkedClear_ImageArray[i].color = Color.red;

            }
        }
        
    }

    void Update()
    {
        
    }

    public void OnClickCheckedClearButton()
    {
        if(panel_Object.activeSelf)
        {
            panel_Object.SetActive(false);
        }
        else
        {
            panel_Object.SetActive(true);

        }
    }

    public void OnClickCameraButton()
    {
        SceneManager.LoadScene("ARScene"); // ī�޶�

    }
}

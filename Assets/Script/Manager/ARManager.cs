using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.XR.ARFoundation;

public class ARManager : MonoBehaviour
{
    public static bool isTrackingSuccess;

    private void Awake()
    {
        isTrackingSuccess = false;
    }
    

    void Update()
    {
        if(isTrackingSuccess)
        {
            this.GetComponent<Multiple_Tracking_Image>().enabled = false;
            this.GetComponent<ARTrackedImageManager>().enabled = false;
            Invoke("MoveScene", 2.0f);
            isTrackingSuccess = false;
        }
    }

    void MoveScene()
    {
        SceneManager.LoadScene("Test1_Tracked");

    }
}

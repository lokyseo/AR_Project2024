using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Tracked_SceneMove : MonoBehaviour
{


    void Start()
    {

        if (this.gameObject.activeSelf)
        {
            ARManager.isTrackingSuccess = true;
            Destroy(this.gameObject);

        }

    }

    void Update()
    {
        if (this.gameObject.activeSelf)
        {
            Destroy(this.gameObject);

        }

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MixedCup_ChasePosition : MonoBehaviour
{
    GameObject chased_Object;

    void Start()
    {
        if (transform.name.Contains("Left"))
        {
            chased_Object = GameObject.FindWithTag("Left");
        }
        else if (transform.name.Contains("Center"))
        {
            chased_Object = GameObject.FindWithTag("Center");

        }
        else if (transform.name.Contains("Right"))
        {
            chased_Object = GameObject.FindWithTag("Right");

        }

    }

    void Update()
    {
        transform.position = chased_Object.transform.position;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipCard : MonoBehaviour
{
    public bool isTouched;
    Quaternion targetRotation;
    void Start()
    {
        isTouched = false; 
    }

    void Update()
    {
        if(isTouched)
        {
            this.GetComponent<BoxCollider>().enabled = false;
            targetRotation = Quaternion.Euler(0, 0, 0);

            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, 3.0f * Time.deltaTime);
        }
        else
        {
            this.GetComponent<BoxCollider>().enabled = true;

            targetRotation = Quaternion.Euler(0, 180, 0);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, 3.0f * Time.deltaTime);
        }
    }
}

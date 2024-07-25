using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildTop_Collision : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Ground"|| collision.gameObject.tag == "Block")
        {

        }
    }
}

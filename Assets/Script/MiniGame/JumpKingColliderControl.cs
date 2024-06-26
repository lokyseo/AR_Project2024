using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpKingColliderControl : MonoBehaviour
{
    Rigidbody rb;

    void Start()
    {
        rb = GameObject.FindWithTag("Player").GetComponent<Rigidbody>();
    }

    void Update()
    {
      
        if(rb.velocity.y > 0)
        {
            this.GetComponent<BoxCollider>().enabled = false;
        }
        else
        {
            this.GetComponent<BoxCollider>().enabled = true;

        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpKingColliderControl : MonoBehaviour
{
    Rigidbody2D rb;
    GameObject player;
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        rb = player.GetComponent<Rigidbody2D>();
    }

    void Update()
    {
      
        if(rb.velocity.y <= 0 && player.transform.localPosition.y > this.transform.localPosition.y  + 90)
        {
            this.GetComponent<BoxCollider2D>().enabled = true;
        }
        else
        {
            this.GetComponent<BoxCollider2D>().enabled = false;

        }
    }
}

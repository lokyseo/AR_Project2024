using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Basket_SpawnObject : MonoBehaviour
{
    void Start()
    {
        float randnum = Random.Range(0.5f, 2f);

        this.GetComponent<Rigidbody2D>().gravityScale = randnum;
    }

    void Update()
    {
        
    }
}

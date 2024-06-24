using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElplodeManager : MonoBehaviour
{
    public GameObject sphere_burst;
    int rand_x;
    int rand_y;

    void Start()
    {
        
    }

    void Update()
    {
       

        for (int i = 0; i < 7; i++)
        {
            rand_x = Random.Range(-(Screen.width / 2), (Screen.width / 2));
            rand_y = Random.Range(-(Screen.height / 2), (Screen.height / 2));

            
            Instantiate(sphere_burst, new Vector3(rand_x, rand_y, 0), Quaternion.identity);
        }

    }
}

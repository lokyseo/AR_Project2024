using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WoodRollChasePlayer : MonoBehaviour
{
    GameObject player_Object;

    void Start()
    {
        player_Object = GameObject.FindWithTag("Player");
    }

    void Update()
    {
        transform.position = player_Object.transform.position;
    }
}

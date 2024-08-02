using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OverlapBlock : MonoBehaviour
{

    private void OnTriggerStay2D(Collider2D collision)
    {
        GetComponent<SpriteRenderer>().color = Color.red;
    }
}

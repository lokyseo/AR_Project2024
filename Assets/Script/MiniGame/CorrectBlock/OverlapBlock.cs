using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OverlapBlock : MonoBehaviour
{
    public bool isFool;
    //public bool isReadyEquip;
    private void Start()
    {
        isFool = false;
        //isReadyEquip = false;
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if ((collision.tag == "Block"))
        {
            GetComponent<Image>().color = Color.red;
           
                isFool = true;
          
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if ((collision.tag == "Block"))
        {
            GetComponent<Image>().color = Color.black;
            isFool = false;
        }
    }
}

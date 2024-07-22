using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroAnimation : MonoBehaviour
{
    [SerializeField] 
    GameObject canvas;

    public void Activeoff()
    {
        canvas.SetActive(false);
    }
    
    public void EndAnimation()
    {
        this.gameObject.SetActive(false);
    }
}

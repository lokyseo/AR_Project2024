using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestScript : MonoBehaviour
{
    [SerializeField] private GameObject window;
    public void WindowOnOff()
    {
        window.SetActive(!window.activeSelf);
    }

}

using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class WoodRollCollision : MonoBehaviour
{
    private float time = 10.0f;
    public TextMeshProUGUI time_Text;
    private void Update()
    {
        time -= Time.deltaTime;
        time_Text.text = time.ToString("F1");
        if (time < 0)
        {
            time_Text.text = "0";
            SceneManager.LoadScene("MainScene");
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}

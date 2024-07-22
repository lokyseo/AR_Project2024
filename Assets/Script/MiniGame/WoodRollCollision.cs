using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class WoodRollCollision : MonoBehaviour
{
    private float time;
    public TextMeshProUGUI time_Text;

    public Image[] player_Health;
    int count_Health;
    Vector3 startPosition;

    public GameObject wood_Object;
    GameObject player_Object;
    float moveSpeed;
    float rotTime;
    int randnum;

    void Start()
    {
        player_Object = GameObject.FindWithTag("Player");
        startPosition = player_Object.transform.position;
        rotTime = Random.Range(0.5f, 3f);

        moveSpeed = 3.5f;
        time = 0.0f;
    }

    void Update()
    {
        if (!player_Health[2].gameObject.activeSelf)
        {
            SceneManager.LoadScene("MainScene");
        }

        time += Time.deltaTime;
        time_Text.text = time.ToString("F1");
        if (time >= 10.0f)
        {
            time_Text.text = "10.0";
            SceneManager.LoadScene("MainScene");
        }

        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Moved || touch.phase == TouchPhase.Stationary)
            {
                if (touch.position.x < Screen.width / 2)
                {
                    player_Object.transform.Translate(Vector3.left * moveSpeed * Time.deltaTime, Space.World);
                }
                else if (touch.position.x >= Screen.width / 2)
                {
                    player_Object.transform.Translate(Vector3.right * moveSpeed * Time.deltaTime, Space.World);

                }
            }

        }
        rotTime -= Time.deltaTime;

        if (rotTime < 0)
        {
            rotTime = Random.Range(0.5f, 3f);
            randnum = Random.Range(0, 2);

        }

        if (randnum == 0)
        {
            wood_Object.transform.Rotate(Vector3.forward, 25.0f * Time.deltaTime);

        }
        else
        {
            wood_Object.transform.Rotate(Vector3.forward, -25.0f * Time.deltaTime);

        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            player_Health[count_Health].gameObject.SetActive(false);
            count_Health++;

            player_Object.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
            player_Object.transform.position = startPosition;
            time = 0.0f;
        }
    }
}

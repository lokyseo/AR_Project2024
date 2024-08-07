using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Basket_PlayerObject : MonoBehaviour
{
    public float moveSpeed;

    int scoreHeart;

    private void Start()
    {
        moveSpeed = 5f;
        scoreHeart = 0;
    }
    void Update()
    {
        if(scoreHeart > 5)
        {
            SceneManager.LoadScene("MainScene");
        }

        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began || touch.phase == TouchPhase.Moved || touch.phase == TouchPhase.Stationary)
            {
                if (touch.position.x < Screen.width / 2)
                {
                    MoveLeft();
                }
                else if (touch.position.x > Screen.width / 2)
                {
                    MoveRight();
                }
            }
        }
    }

    void MoveLeft()
    {
        transform.Translate(Vector2.left * moveSpeed * Time.deltaTime);
    }

    void MoveRight()
    {
        transform.Translate(Vector2.right * moveSpeed * Time.deltaTime);
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Trap")
        {

        }
        else if (collision.gameObject.tag == "Point")
        {
            Destroy(collision.gameObject);
            scoreHeart++;
        }
    }

}

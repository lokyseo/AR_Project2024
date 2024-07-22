using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class NailManager : MonoBehaviour
{
    public Transform targetRotation;

    public GameObject board;
    bool isCollision;

    bool isHammer;
    int collisionCount;

    public Image[] player_Health;
    int count_Health;

    void Start()
    {
        isHammer = false;
        isCollision = false;
        collisionCount = 0;

        count_Health = 0;
    }

    void Update()
    {
        if (!player_Health[2].gameObject.activeSelf)
        {
            SceneManager.LoadScene("MainScene");
        }

        board.transform.position += new Vector3(1, 0, 0) * Time.deltaTime;

        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                isHammer = true;
                isCollision = false;
            }

        }

        if(isHammer)
        {
            targetRotation.localEulerAngles = new Vector3(0, 0, 90);
            this.transform.rotation = Quaternion.RotateTowards(this.transform.rotation, targetRotation.rotation, 500.0f * Time.deltaTime);
            if(this.transform.localEulerAngles.z >= 90)
            {
                if(!isCollision)
                {
                    player_Health[count_Health].gameObject.SetActive(false);
                    count_Health++;
                }

                isHammer = false;

            }
        }
        else
        {
            targetRotation.localEulerAngles = new Vector3(0, 0, 0);
            this.transform.rotation = Quaternion.RotateTowards(this.transform.rotation, targetRotation.rotation, 500.0f * Time.deltaTime);

        }
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name.Contains("Nail"))
        {
            collision.transform.localPosition -= new Vector3(0, 0.7f, 0);
            isCollision = true;
            collisionCount++;
            if(collisionCount == 4)
            {
                SceneManager.LoadScene("MainScene");
            }
           
        }
    }

}

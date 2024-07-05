using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WoodRollMiniGame : MonoBehaviour
{
    public GameObject wood_Object;
    GameObject player_Object;
    Rigidbody2D player_rigid;
    public GameObject basic_Transform;
    float moveSpeed;
    float rotTime;
    int randnum;

    void Start()
    {
        player_Object = GameObject.FindWithTag("Player");
        rotTime = Random.Range(0.5f, 3f);
        player_rigid = player_Object.GetComponent<Rigidbody2D>();

        moveSpeed = 2.0f;
    }

    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                player_Object.transform.parent = basic_Transform.transform;

            }

            if (touch.phase == TouchPhase.Moved || touch.phase == TouchPhase.Stationary)
            {
                if (touch.position.x < Screen.width / 2)
                {
                    player_rigid.velocity = new Vector2(-moveSpeed , player_rigid.velocity.y);
                    //player_Object.transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);
                }
                else if (touch.position.x >= Screen.width / 2)
                {
                    player_rigid.velocity = new Vector2(moveSpeed, player_rigid.velocity.y);
                    //player_Object.transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);

                }
            }

            if (touch.phase == TouchPhase.Ended)
            {
                player_Object.transform.parent = wood_Object.transform;

            }
        }
        rotTime -= Time.deltaTime;

        if(rotTime < 0)
        {
            rotTime = Random.Range(0.5f, 3f);
            randnum = Random.Range(0, 2);

        }

        if (randnum == 0)
        {
            wood_Object.transform.Rotate(Vector3.forward, 20.0f * Time.deltaTime);

        }
        else
        {
            wood_Object.transform.Rotate(Vector3.forward, -20.0f * Time.deltaTime);

        }
    }
}

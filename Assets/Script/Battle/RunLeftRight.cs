using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class RunLeftRight : MonoBehaviour
{
    private Vector2 startTouchPosition, endTouchPosition;
    private float minSwipeDistance = 50f;
    GameObject player_Object;
    public GameObject total_Obstacle;

    public GameObject obstacle;
    float spawnTime;

    void Start()
    {
        player_Object = GameObject.FindWithTag("Player");
        spawnTime = 1.0f;
    }

    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                startTouchPosition = touch.position;
            }
            else if (touch.phase == TouchPhase.Ended)
            {
                endTouchPosition = touch.position;
                DetectSwipe();
            }
        }

        SpawnObstacle();
    }

    void SpawnObstacle()
    {
        spawnTime -= Time.deltaTime;
        if (spawnTime < 0.0f)
        {
            spawnTime = 2.0f;
            GameObject spawnObject =Instantiate(obstacle);
            spawnObject.transform.SetParent(total_Obstacle.transform);
            int randNum = Random.Range(0, 3);
            switch (randNum)
            {
                case 0: randNum = -300;
                    break;
                case 1:
                    randNum = 0;
                    break;
                case 2:
                    randNum = 300;
                    break;
            }

            spawnObject.transform.localPosition = total_Obstacle.transform.position + new Vector3(randNum, 0, 0);
        }
    }

    private void DetectSwipe()
    {
        if (Vector2.Distance(startTouchPosition, endTouchPosition) >= minSwipeDistance)
        {
            Vector2 direction = endTouchPosition - startTouchPosition;
            if (Mathf.Abs(direction.x) > Mathf.Abs(direction.y))
            {
                if (direction.x > 0)
                {
                    //Vector3 targetPosition = new Vector3(360, player_Object.transform.position.y, player_Object.transform.position.z);
                    //player_Object.transform.position = 
                    //    Vector3.Lerp(player_Object.transform.position, targetPosition, 10.0f * Time.deltaTime);
                    //
                    //if (Vector3.Distance(player_Object.transform.position, targetPosition) < 0.01f)
                    //{
                    //    player_Object.transform.position = targetPosition;
                    //}

                    if (player_Object.transform.localPosition.x >= 360)
                        return;
                    player_Object.transform.localPosition += new Vector3(360, 0, 0);
                }
                else
                {
                    if (player_Object.transform.localPosition.x <= -360)
                        return;
                    player_Object.transform.localPosition += new Vector3(-360, 0, 0);
                }
            }
        }
    }
}

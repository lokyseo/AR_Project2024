using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Basket_Manager : MonoBehaviour
{
    public Transform spawnPoint;
    public GameObject plus_spawnPrefab;
    public GameObject minus_spawnPrefab;

    float spawnCooltime;

    
    private void Start()
    {
        spawnCooltime = 1.0f;    
    }

    private void Update()
    {
       spawnCooltime -= Time.deltaTime;

        if(spawnCooltime < 0.0f)
        {
            spawnCooltime = 1.0f;
            int randNum = Random.Range(0, 10);
            float randWidth = Random.Range(-(Screen.width / 2 + 25), (Screen.width / 2 -25));

            GameObject temp;
            if (randNum <= 3)
            {
                temp = Instantiate(minus_spawnPrefab);
            }
            else
            {
                temp =Instantiate(plus_spawnPrefab);
            }
            temp.transform.SetParent(spawnPoint.transform);
            temp.transform.localPosition = new Vector3(randWidth, spawnPoint.position.y, 0);

        }
    }


}

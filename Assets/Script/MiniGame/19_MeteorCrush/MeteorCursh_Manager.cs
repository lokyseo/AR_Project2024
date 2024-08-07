using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MeteorCursh_Manager : MonoBehaviour
{
    public GameObject meteor;
    public GameObject spawnTotal;
    float coolTime;
    int countDestroy;
    void Start()
    {
        coolTime = 1.0f;
        countDestroy = 0;
    }

    void Update()
    {
        coolTime -= Time.deltaTime;
        if(coolTime < 0 )
        {
            SpawnMeteor();
            coolTime = 1.0f;
        }

        

        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            Ray ray = Camera.main.ScreenPointToRay(touch.position);
            RaycastHit hit;

            if (touch.phase == TouchPhase.Began)
            {
                if (Physics.Raycast(ray, out hit))
                {
                    if (hit.collider.tag == "Explode_Sphere")
                    {
                        Destroy(hit.collider);
                        countDestroy++;

                        if(countDestroy >= 10)
                        {
                            SceneManager.LoadScene("MainScene");
                        }
                    }

                }

               
                if (touch.phase == TouchPhase.Ended)
                {

                }

            }
        }
    }

    public void SpawnMeteor()
    {
        int randnum = Random.Range(0, 4);

        Instantiate(meteor, spawnTotal.transform.GetChild(randnum).transform.position, Quaternion.identity);
    }
}

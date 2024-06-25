using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ElplodeManager : MonoBehaviour
{
    public GameObject sphere_burst;
    public Image count_Image;
    public GameObject card_Prefab;


    GameObject[] test = new GameObject[20];
    int rand_num;
    int[] number_Array = new int[20];
    int current_num;

    public Transform StartPos;
    public Transform bg_Parent;


    void Start()
    {
        current_num = 1;
        StartCoroutine(CountNumber());

    }

    void Update()
    {
        

        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            Ray ray = Camera.main.ScreenPointToRay(touch.position);
            RaycastHit hit;

            

            if (touch.phase == TouchPhase.Began)
            {
                if (Physics.Raycast(ray, out hit))
                {
                    if (hit.transform.tag == "Explode_Sphere" && current_num.ToString() == hit.transform.GetComponentInChildren<Text>().text)
                    {
                        current_num++;
                        Destroy(hit.transform.gameObject);

                        if (current_num > 20)
                        {
                            GameObject card;

                            card = Instantiate(card_Prefab);
                            card.transform.parent = bg_Parent;
                            card.transform.localPosition = new Vector3(0, 0, 0);
                        }
                    }

                    if(hit.transform.tag == "Card")
                    {
                        Destroy(hit.transform.gameObject);
                        SceneManager.LoadScene("MainScene");
                    }
                }
            }

            if (touch.phase == TouchPhase.Moved)
            {

            }
            if (touch.phase == TouchPhase.Ended)
            {

            }

        }
    }

    IEnumerator CountNumber()
    {
        count_Image.GetComponentInChildren<Text>().text = "3";
        yield return new WaitForSeconds(1.0f);
        count_Image.GetComponentInChildren<Text>().text = "2";
        yield return new WaitForSeconds(1.0f);
        count_Image.GetComponentInChildren<Text>().text = "1";
        yield return new WaitForSeconds(1.0f);
        count_Image.gameObject.SetActive(false);

        CreateSphere();

    }


    void CreateSphere()
    {
        for (int i = 0; i < 20; i++)
        {
            test[i] = Instantiate(sphere_burst, new Vector3(0, 0, 0), Quaternion.identity);
            test[i].transform.parent = bg_Parent;
            test[i].transform.localPosition = StartPos.localPosition + new Vector3((i % 4) * 250, -(i / 4) * 400, 0);

            rand_num = Random.Range(1, 21);

            for (int j = 0; j < 20;)
            {
                if (number_Array.Contains(rand_num))
                {
                    rand_num = Random.Range(1, 21);
                }
                else
                {
                    j++;
                }
            }
            number_Array[i] = rand_num;
            test[i].GetComponentInChildren<Text>().text = rand_num.ToString();
        }
    }

}


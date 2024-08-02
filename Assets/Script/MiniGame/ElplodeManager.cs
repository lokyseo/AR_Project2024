using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class ElplodeManager : MonoBehaviour
{
    public Image count_Image;

    [SerializeField] int current_num;


    [SerializeField]
    private List<Button> buttons = new List<Button>();

    [SerializeField]
    private List<Sprite> sprites = new List<Sprite>();

    [SerializeField]
    private List<GameObject> robotParts = new List<GameObject>();

    public UnityEvent gameStart;

    float clearTime;
    public TextMeshProUGUI time_Text;

    void Start()
    {
        current_num = 0;
        InitImage();
        StartCoroutine(CountNumber());
        clearTime = 10.0f;
    }
    void Update()
    {
        clearTime -= Time.deltaTime;
        time_Text.text = clearTime.ToString("F1");

        if (clearTime < 0)
        {
            time_Text.text = "0.0";
            SceneManager.LoadScene("MainScene");
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
        gameStart.Invoke();
        clearTime = 10.0f;
    }

    private void InitImage()
    {
        buttons = buttons.OrderBy(x => Guid.NewGuid()).ToList();

        for (int id = 0; id < buttons.Count; id++) 
        {
            buttons[id].transform.GetComponent<Image>().sprite = sprites[id];
            buttons[id].transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = (id+1).ToString();
            int number = id;
            buttons[id].onClick.AddListener(() => OnClickButton(number));
        }
    }

    private void OnClickButton(int id)
    {
        Debug.Log(id);
        if (id != current_num)
        {
            return;
        }

        robotParts[id].SetActive(true);
        buttons[id].gameObject.SetActive(false);
        current_num++;

        if (current_num == buttons.Count)
        {
            SceneManager.LoadScene("MainScene");
        }
    }

}


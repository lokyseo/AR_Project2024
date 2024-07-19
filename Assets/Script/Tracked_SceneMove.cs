using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Tracked_SceneMove : MonoBehaviour
{
    float timeCount;
    [SerializeField]
    private GameData gameData;

    private void OnEnable()
    {
        timeCount = 1.0f;
    }

    void Start()
    {
        timeCount = 1.0f;

    }

    void Update()
    {
        timeCount -= Time.deltaTime;
        if(timeCount < 0.0f)
        {
            timeCount = 1.0f;
            
            //this.gameObject.SetActive(false);
            int id = Random.Range(0, 1);

            SceneManager.LoadScene(gameData.stages[id].sceneName);
            Camera.main.Reset();

        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MoveScene : MonoBehaviour
{
    [SerializeField]
    private GameData gameData;

    public void SceneMove(string SceneName)
    {
        SceneManager.LoadScene(SceneName);    
    }

    public void SceneMoveById(int id)
    {
        SceneManager.LoadScene(gameData.stages[id].sceneName);
    }
}

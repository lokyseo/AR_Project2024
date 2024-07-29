using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainManager : MonoBehaviour
{
    [SerializeField]
    SaveData saveData;

    private void Start()
    {
        if (saveData == null)
        {
            saveData = new SaveData();
            SaveSystem.DataSave(saveData);
        }
        saveData = SaveSystem.DataLoad();


    }










    /*��� ���°�¡
     * 
     * public Image[] checkedClear_ImageArray;
        public GameObject panel_Object;

        void Start()
        {
            for(int i = 0; i < checkedClear_ImageArray.Length; i++)
            {
                if (PlayerPrefs.GetInt("MiniGame" + (i + 1) + "Clear", 0) != 0)
                {
                    checkedClear_ImageArray[i].color = Color.green;
                }
                else
                {
                    checkedClear_ImageArray[i].color = Color.red;

                }
            }

        }

        public void OnClickCheckedClearButton()
        {
            panel_Object.SetActive(!panel_Object.activeSelf);
        }*/

    public void OnClickCameraButton()
    {
        SceneManager.LoadScene("ARScene"); // ī�޶�

    }
}

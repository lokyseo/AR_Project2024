using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public static class SaveSystem
{
    public static void DataSave(SaveData saveData)
    {
        try
        {
            BinaryFormatter formatter = new BinaryFormatter();
            string path = Application.persistentDataPath + "/Player.fun";
            using (FileStream stream = new FileStream(path, FileMode.Create))
            {
                formatter.Serialize(stream, saveData);
            }
            Debug.Log("Data saved successfully at " + path);
        }
        catch (System.Exception e)
        {
            Debug.LogError("Failed to save data: " + e.Message);
        }
    }

    public static SaveData DataLoad()
    {
        string path = Application.persistentDataPath + "/Player.fun";
        if (File.Exists(path))
        {
            try
            {
                BinaryFormatter formatter = new BinaryFormatter();
                using (FileStream stream = new FileStream(path, FileMode.Open))
                {
                    SaveData saveData = formatter.Deserialize(stream) as SaveData;
                    Debug.Log("로딩 성공");
                    return saveData;
                }
            }
            catch (System.Exception e)
            {
                Debug.LogError("Failed to load data: " + e.Message);
                return null;
            }
        }
        else
        {
            Debug.LogWarning("파일이 읎다");
            return null;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SaveData
{
    public List<Item> items;

    public SaveData()
    {
        items = new List<Item>();
    }

    public SaveData(SaveData data)
    {
        foreach (var item in data.items)
        {
            items.Add(item.Clone());
        }
    }
}

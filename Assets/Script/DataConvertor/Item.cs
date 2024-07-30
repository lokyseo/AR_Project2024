using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Item
{
    public int id;
    public string name;
    public string description;
    public string imageAddress;
    public List<int> needPartID;


    public Item Clone()
    {
        Item Clone = new Item();
        Clone.id = id;
        Clone.name = name;
        Clone.description = description;
        Clone.imageAddress = imageAddress;
        Clone.needPartID = needPartID.ConvertAll(s => s); // immutable 타입이라 가능

        return Clone;
    }
}

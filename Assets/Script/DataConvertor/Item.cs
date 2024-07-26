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
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Weapon 
{
    public int id;
    public string name;
    public string description;

    public int attackSpeed;
    public int damage;

    public Elemental elemental;

    [HideInInspector]
    public float destroyPercent;
    public float failPercent;
    public float successPercent;
    public int upgradeCost;
    public string imageAddress;
}

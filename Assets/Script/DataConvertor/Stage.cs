using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Stage
{
    public int id;
    public string name;
    public int themeId;
    public List<Elemental> StrongElementals;
    public List<Elemental> WeekElementals;
    public string stageMonster;
}

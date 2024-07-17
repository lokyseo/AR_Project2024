using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueScript : ScriptableObject
{
#if UNITY_EDITOR
    [ArrayElementTitle("description")]
#endif    
    public List<Script> introScript;
}

[System.Serializable]
public class Script
{
    public int id;
    public string name;
    public string description;
}
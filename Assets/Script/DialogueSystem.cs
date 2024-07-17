using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using System.Reflection;
using System;

public class DialogueSystem : MonoBehaviour
{
    [Header("UI")]
    public TextMeshProUGUI name;
    public TextMeshProUGUI description;

    [Header("데이터")] 
    public DialogueScript dialogues;
    public string ScriptName;
    public List<Script> Script;

    public UnityEvent EndDialogue;
    private void Start()
    {
        LoadScripts(ScriptName);
        GetDialouge(0);
    }

    public void LoadScripts(string scriptName)
    {
        if (dialogues != null)
        {
            // 리플렉션을 사용하여 introScript 필드에 접근
            FieldInfo fieldInfo = typeof(DialogueScript).GetField(scriptName);
            if (fieldInfo != null)
            {
                Script = fieldInfo.GetValue(dialogues) as List<Script>;
                Debug.Log("introScript value: " + Script);
            }
            else
            {
                Debug.LogError("Field 'introScript' not found.");
            }
        }
    }

    private int id = 0;
    public void OnNextDialouge()
    {
        id = id + 1;
        if (id >= Script.Count)
        {
            EndDialogue.Invoke();
            return;
        }
        GetDialouge(id);
    }

    public void GetDialouge(int id)
    {
        name.text = Script[id].name;
        description.text = Script[id].description;
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEditor;
using UnityEngine;
using UnityEngine.U2D;

public class GameData : ScriptableObject
{

#if UNITY_EDITOR
    [ArrayElementTitle("name")]
#endif    
    public List<Stage> stages;
}

public enum Zone
{
    Entrance,
    Future,
    Robot,
    Adventure,
    Dream
}


#if UNITY_EDITOR
public class ArrayElementTitleAttribute : PropertyAttribute
{
    public string Varname;
    public ArrayElementTitleAttribute(string ElementTitleVar)
    {
        Varname = ElementTitleVar;
    }
}
[CustomPropertyDrawer(typeof(ArrayElementTitleAttribute))]
public class ArrayElementTitleDrawer : PropertyDrawer
{
    public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
    {
        return EditorGUI.GetPropertyHeight(property, label, true);
    }

    protected virtual ArrayElementTitleAttribute Attribute => attribute as ArrayElementTitleAttribute;
    SerializedProperty TitleNameProp;

    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        string FullPathName = property.propertyPath + "." + Attribute.Varname;
        TitleNameProp = property.serializedObject.FindProperty(FullPathName);
        string newLabel = GetArrayIndex(property) + ". " +GetTitle();
        if (string.IsNullOrEmpty(newLabel))
            newLabel = label.text;

        EditorGUI.PropertyField(position, property, new GUIContent(newLabel, label.tooltip), true);
    }

    string GetTitle()
    {
        switch (TitleNameProp.propertyType)
        {
            case SerializedPropertyType.Generic:
                break;
            case SerializedPropertyType.Integer:
                return TitleNameProp.intValue.ToString();
            case SerializedPropertyType.Boolean:
                return TitleNameProp.boolValue.ToString();
            case SerializedPropertyType.Float:
                return TitleNameProp.floatValue.ToString();
            case SerializedPropertyType.String:
                return TitleNameProp.stringValue;
            case SerializedPropertyType.Color:
                return TitleNameProp.colorValue.ToString();
            case SerializedPropertyType.ObjectReference:
                return TitleNameProp.objectReferenceValue.ToString();
            case SerializedPropertyType.LayerMask:
                break;
            case SerializedPropertyType.Enum:
                return TitleNameProp.enumNames[TitleNameProp.enumValueIndex];
            case SerializedPropertyType.Vector2:
                return TitleNameProp.vector2Value.ToString();
            case SerializedPropertyType.Vector3:
                return TitleNameProp.vector3Value.ToString();
            case SerializedPropertyType.Vector4:
                return TitleNameProp.vector4Value.ToString();
            case SerializedPropertyType.Rect:
                break;
            case SerializedPropertyType.ArraySize:
                break;
            case SerializedPropertyType.Character:
                break;
            case SerializedPropertyType.AnimationCurve:
                break;
            case SerializedPropertyType.Bounds:
                break;
            case SerializedPropertyType.Gradient:
                break;
            case SerializedPropertyType.Quaternion:
                break;
            case SerializedPropertyType.ExposedReference:
                break;
            case SerializedPropertyType.FixedBufferSize:
                break;
            case SerializedPropertyType.Vector2Int:
                break;
            case SerializedPropertyType.Vector3Int:
                break;
            case SerializedPropertyType.RectInt:
                break;
            case SerializedPropertyType.BoundsInt:
                break;
            default:
                break;
        }
        return "";
    }
    int GetArrayIndex(SerializedProperty property)
    {
        // 배열 요소의 인덱스를 가져오는 방법은 property.propertyPath를 분석해서 찾을 수 있습니다.
        // 예를 들어, "myArray.Array.data[3]"와 같은 형태로 되어 있을 것입니다.
        string path = property.propertyPath;
        // "data[인덱스]" 부분을 추출합니다.
        int startIndex = path.IndexOf("[") + 1;
        int endIndex = path.IndexOf("]");
        string indexString = path.Substring(startIndex, endIndex - startIndex);
        // 인덱스 문자열을 정수로 변환합니다.
        int index;
        int.TryParse(indexString, out index);
        return index;
    }
}
#endif
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.Data;
using ExcelDataReader;
using System.IO;
using System;
using System.Reflection;
using NUnit.Framework;
public class ExcelToScriptableObject
{
    [MenuItem("GameData/Create")]
    public static GameData CreateGameDB()
    {
        var assetPath = "Assets/Excels/GameData.asset";
        var excelPath = "Assets/Excels/GameData.xlsx";

        var gameData = AssetDatabase.LoadAssetAtPath<GameData>(assetPath);  // Path �� ���ؼ� ��������ִ� Asset�� �о�´�.

        if (gameData == null)                                               // ������� �����Ͱ� ���ٸ� ���� ������ش�.
        {
            gameData = ScriptableObject.CreateInstance<GameData>();
            AssetDatabase.CreateAsset(gameData, assetPath);
        }

        DataSet excelData = GetExcelDataSet(excelPath);                   // ExcelPath�� ���� ������ �о� DataSet���·� �޾ƿ´�.
        FillData<GameData>(gameData, excelData);

        EditorUtility.SetDirty(gameData);
        AssetDatabase.SaveAssets();
        AssetDatabase.Refresh();

        return gameData;
    }

    /// <summary>
    /// ExcelReader�� �̿��� ExcelPath�� ���� �����͸� DataSet���� ��ȯ�Ѵ�.
    /// </summary>
    /// <param name="excelPath">���������� ���</param>
    /// <returns>���������� ���� DataSet������ ����</returns>
    public static DataSet GetExcelDataSet(string excelPath)
    {
        using (var stream = File.Open(excelPath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
        {
            using (var reader = ExcelReaderFactory.CreateReader(stream))
            {
                return reader.AsDataSet();
            }
        }
    }

    public static void FillData<T>(T data, DataSet dataSet)
    {
        var dataType = typeof(T);
        var fieldInfos = dataType.GetFields();

        var thisScriptType = typeof(ExcelToScriptableObject);
        var makeListMethod = thisScriptType.GetMethod("MakeList");

        foreach (var fieldinfo in fieldInfos)
        {
            var fieldType = fieldinfo.FieldType;

            if (!fieldType.IsGenericType || fieldType.GetGenericTypeDefinition() != typeof(List<>))     //���׸� Ÿ�԰� ����Ʈ Ÿ���� �ƴҰ�� ��ŵ�Ѵ�.
            {
                continue;
            }

            var listArg = fieldType.GetGenericArguments()[0];
            if (listArg == typeof(Sprite))
            {
                return;
            }
            //� Ÿ���� ����Ʈ���� Ȯ��. ex) List<A> ��� AŸ�� ����Ʈ
            var method = makeListMethod.MakeGenericMethod(listArg);
            var items = method.Invoke(null, new object[] { dataSet, fieldinfo.Name });

            fieldinfo.SetValue(data, items);

        }
    }


    public static List<T> MakeList<T>(DataSet dataSet, string TableName) where T : new()
    {
        var table = SelectDataTable(dataSet, TableName);
        if (table == null)
        {
            throw new Exception(TableName + "ã�� �� ����");
        }


        List<String> columns = new List<String>();

        int columnCount = table.Columns.Count;
        int rowCount = table.Rows.Count;
        var type = typeof(T);

        List<T> datalist = new List<T>();

        for (int row = 1; row < rowCount; row++)
        {
            var item = new T();
            Dictionary<string, object> dict = new Dictionary<string, object>();

            for (int col = 0; col < columnCount; col++)
            {
                var fieldName = table.Rows[0][col].ToString();
                var field = type.GetField(fieldName);

                if (field == null)
                {
                    continue;
                }

                var value = table.Rows[row][col];
                object val = null;
                try
                {
                    if (field.FieldType.IsGenericType && field.FieldType.GetGenericTypeDefinition() == typeof(List<>)) // GameData -> List<A> -> (A - > List<B>)�� ����ִ���
                    {
                        if (value.ToString() == "")
                        {
                            continue;
                        }

                        
                        string[] values = ((string)value).Split(",");

                        foreach (string str in values)
                        {
                            dict.TryGetValue(fieldName, out val);
                            if (val == null)
                            {
                                dict[fieldName] = Activator.CreateInstance(field.FieldType);
                            }
                            var ListB = dict[fieldName];
                            Debug.Log(fieldName + "   " + ListB);

                            Type listArg = field.FieldType.GetGenericArguments()[0];

                            MethodInfo addMethod = field.FieldType.GetMethod("Add");

                            object valueForAdd = new object();
                            if (listArg.IsEnum)
                            {
                                valueForAdd = Enum.Parse(listArg, str.ToString());
                            }
                            else
                            {
                                valueForAdd = Convert.ChangeType(str, listArg);
                            }
                            Debug.Log(valueForAdd);

                            addMethod.Invoke(ListB, new object[] { valueForAdd });
                            field.SetValue(item, ListB);
                        }

                        continue;
                    } else if (field.FieldType.IsAssignableFrom(typeof(IParsable)))                    // structre or Class�ϰ�� �� �⺻Ÿ���� �ƴѰ�� ����Parse�� ���ο� ����
                    {
                        var parsable = (IParsable)Activator.CreateInstance(field.FieldType);
                        parsable.Parse(value.ToString());
                        val = parsable;
                    }
                    else if (field.FieldType.IsEnum)
                    {
                        val = Enum.Parse(field.FieldType, value.ToString());
                    }
                    else
                    {
                        val = Convert.ChangeType(value, field.FieldType);
                    }
                }
                catch (Exception e)
                {
                    if (e == new NullReferenceException())
                    {
                        Debug.Log("");
                    }
                }



                field.SetValue(item, val);
            }
            datalist.Add(item);
        }

        return datalist;
    }

    public static DataTable SelectDataTable(DataSet dataSet, string TableName)
    {
        foreach (DataTable table in dataSet.Tables)
        {
            if (table.TableName == TableName)
            {
                return table;
            }
        }
        return null;
    }
}



interface IParsable
{
    public void Parse(string str);
}
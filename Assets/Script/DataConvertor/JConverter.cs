using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;

namespace Jack
{
    public static class JConverter
    {
        public static List<string> BrackeStringToStringList(string s,char StartChar = '{', char EndChar = '}')
        {
            s.Replace(" ", ""); // ��������
            List<string> list = new List<string>();
            bool isOpen = false;
            string saveString = "";
            foreach (var c in s)
            {
                if (c == StartChar)
                {
                    isOpen = true;
                    saveString = "";
                    continue;
                }

                if (c == EndChar)
                {
                    isOpen = false;
                    list.Add(saveString);
                    continue;
                }
                if (isOpen)
                {
                    saveString += c;
                }
            }

            if (isOpen)
            {
                Debug.LogError("������ ������ �����!\n" + s);
            }

            return list;
        }
    }
}

﻿using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using UnityEditor;
using UnityEngine;

namespace CustomTool
{

    public class AutoAddNameSpace : UnityEditor.AssetModificationProcessor
    {
        private static string _path = "Assets/Editor/AutoAddNamespace/Cache/";
        private static string _dataName = "Data.asset";

        private static void OnWillCreateAsset(string path)
        {
            if (!IsOn())
                return;
            
            path = path.Replace(".meta", "");
            if (path.EndsWith(".cs"))
            {
                string text = "";
                text += File.ReadAllText(path);
                string name = GetClassName(text);
                if (string.IsNullOrEmpty(name))
                {
                    return;
                }
                var newText = GetNewScriptContext(name);
                File.WriteAllText(path, newText);
            }
            AssetDatabase.Refresh();
        }

        public static NamespaceData GetData()
        {
            return AssetDatabase.LoadAssetAtPath<NamespaceData>(_path + _dataName);
        }

        private static bool IsOn()
        {
            NamespaceData data = GetData();
            if (data != null)
            {
                return data.IsOn;
            }

            return false;
        }

        //获取新的脚本内容
        private static string GetNewScriptContext(string className)
        {
            var script = new ScriptBuildHelp();
            script.WriteUsing("UnityEngine");
            script.WriteEmptyLine();
            var data = AddNamespaceWindow.GetData();
            string name = data == null ? "UIFrame" : data.name;
            script.WriteNamespace(name);

            script.IndentTimes++;
            script.WriteClass(className, "MonoBehaviour");

            script.IndentTimes++;
            List<string> keys = new List<string>();
            keys.Add("void");
            script.WriteFun(keys, "Start");
            return script.ToString();
        }

        //获取类名
        private static string GetClassName(string text)
        {
            string patterm = "public class ([A-Za-z0-9_]+)\\s*:\\s*MonoBehaviour";
            var match = Regex.Match(text, patterm);
            if (match.Success)
            {
                return match.Groups[1].Value;
            }

            return "";
        }
    }
}


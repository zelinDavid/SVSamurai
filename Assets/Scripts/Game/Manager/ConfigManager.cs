using System.IO;
using UnityEngine;
using Util;

namespace Game
{
    public class ConfigManager : SingletonBase<ConfigManager>      
    {
         public T LoadJson<T>(string path){
             string json = "";
             if (File.Exists(path))
             {
                 json = File.ReadAllText(path);
             }else{
                Debug.LogError("loadJson Fail:" + path);
             }

            return JsonUtility.FromJson<T>(json);
         }
    }
}

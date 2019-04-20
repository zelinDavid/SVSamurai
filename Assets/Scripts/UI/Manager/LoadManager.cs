using UnityEngine;
using Util;

namespace Manager {
    public interface ILoad {
        T Load<T> (string path, string name) where T : class;
        GameObject LoadAndInstaniate (string path, Transform parent);
        T[] LoadAll<T> (string path) where T : Object;
    }

    public class LoadManager :SingletonBase<LoadManager>, ILoad 
    {
        public T Load<T>(string path, string name) where T : class
        {
           return Resources.Load(path + name) as T;
        }

        public T[] LoadAll<T>(string path) where T : Object
        {
            return Resources.LoadAll<T>(path);
        }

        public GameObject LoadAndInstaniate(string path, Transform parent)
        {
           var tem = Resources.Load<GameObject>(path);
            if (tem == null)
            {
                Debug.LogError("path is no exists:" + path);
                return null;
            }else {
                 var go = Object.Instantiate(tem, parent);
                 return go;
            }
        }
    }
}
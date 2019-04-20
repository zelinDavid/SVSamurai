using UnityEngine;

namespace Util
{
    public class SingletonBase<T> where T: class, new()     
    {
         public static T Instance{get; protected set;} = new T();
    }
}

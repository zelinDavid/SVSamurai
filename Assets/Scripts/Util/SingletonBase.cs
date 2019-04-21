using UnityEngine;

namespace Util
{
    public class SingletonBase<T> where T: class, new()     
    {
         public static T Single{get; protected set;} = new T();
    }
}

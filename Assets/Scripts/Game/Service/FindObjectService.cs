 
using UnityEngine;

namespace Game.Service
{
    public class FindObjectService : IFindObjecService     
    {
        public void Init(Contexts contexts)
        {
            contexts.service.SetGameServiceFindObjectService(this);
        }

        public T[] FindAllType<T>() where T : Object
        {
            T[] temp = GameObject.FindObjectsOfType<T>();
            if (temp == null || temp.Length == 0)
            {
                Debug.LogError("findAllType error");
            }
            return temp;
        }

        public IView[] FindAllView()
        {
            return FindAllType<ViewBase>();
        }

        public int GetPriority()
        {
            return 0;
        }

      
    }
}

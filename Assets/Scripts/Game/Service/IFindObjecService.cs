using System;
using UnityEngine;

namespace Game.Service
{
    public interface IFindObjecService:IInitService {
        T[] FindAllType<T>() where T: UnityEngine.Object;
        IView[] FindAllView();
    }
}

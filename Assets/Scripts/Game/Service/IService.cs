using UnityEngine;

namespace Game.Service {
    public interface IInitService {
        void Init(Contexts contexts);
        int GetPriority();
    }

    public interface IExcuteService {
        void Execute();
    }
}
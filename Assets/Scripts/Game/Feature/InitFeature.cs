using UnityEngine;

namespace Game
{
    public class InitFeature : Feature
    {
        public InitFeature(Contexts contexts):base("Init")  
        {
            Add(new ViewFeature(contexts));
            Add(new InputFeature(contexts));
            Add(new GameFeature(contexts));
            Add(new GameEventSystems(contexts));
        }
    }
}

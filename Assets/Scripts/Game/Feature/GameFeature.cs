using UnityEngine;

namespace Game {
    public class GameFeature : Feature {
        public GameFeature(Contexts contexts) {
            InitalizeFun(contexts);
        }

        public void InitalizeFun(Contexts contexts) {
            Add(new GameInitGameSystem(contexts));
        }

        public void ExecuteFun(Contexts contexts) { }

        public void CleanupFun(Contexts contexts) { }

        public void TearDownFun(Contexts contexts) { }

    }
}
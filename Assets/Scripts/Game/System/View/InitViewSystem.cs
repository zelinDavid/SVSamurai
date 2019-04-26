using Entitas;

using UnityEngine;

namespace Game {
    public class InitViewSystem : IInitializeSystem {
        private Contexts _contexts;

        public InitViewSystem(Contexts contexts) {
            _contexts = contexts;
        }

        public void Initialize() {

        }
    }
}
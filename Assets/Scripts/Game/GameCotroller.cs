using Entitas;

using UnityEngine;

namespace Game {
    public class GameCotroller : MonoBehaviour {
        Systems _systems;
        Contexts _contexts;

        private void Awake() {
            _contexts = Contexts.sharedInstance;
        //    _systems = new  
            
        }


        void InitManager(){
            
        }
    }
}
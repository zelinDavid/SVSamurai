using UnityEngine;

namespace Game {
    
    public class InputFeature : Feature {
        
        public InputFeature(Contexts contexts) {
            Add(new InputNullSystem(contexts));
            Add(new InputForwardButtonSystem(contexts));
            Add(new InputLeftButtonSystem(contexts));
            Add(new InputRightButtonSystem(contexts));
            Add(new InputBackButtonSystem(contexts));
        }
    }
}
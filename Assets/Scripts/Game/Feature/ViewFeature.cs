using UnityEngine;

namespace Game {
    public class ViewFeature : Feature, IFeature {
        public ViewFeature(Contexts contexts) : base("View") {
            InitializeFun(contexts);
            ExecuteFun(contexts);
            CleanupFun(contexts);
            TearDownFun(contexts);
            ReactiveSystemFun(contexts);
        }

        public void CleanupFun(Contexts contexts) {
            throw new System.NotImplementedException();
        }

        public void ExecuteFun(Contexts contexts) {
             
        }

        public void InitializeFun(Contexts contexts) {
             
        }

        public void ReactiveSystemFun(Contexts contexts) {
             
        }

        public void TearDownFun(Contexts contexts) {
             
        }
    }
}
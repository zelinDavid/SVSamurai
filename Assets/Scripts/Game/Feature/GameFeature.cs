using UnityEngine;

namespace Game {
    public class GameFeature : Feature {
        public GameFeature(Contexts contexts) {
            InitalizeFun(contexts);
            ReactiveSystemFun(contexts);
        }

        public void InitalizeFun(Contexts contexts) {
            Add(new GameInitGameSystem(contexts));
            Add(new GameHumanAniEventSystem(contexts));
            Add(new SkillManagerSystem(contexts));
            
        }
 
        public void ExecuteFun(Contexts contexts) { }

        public void CleanupFun(Contexts contexts) { }

        public void TearDownFun(Contexts contexts) { }

        public void ReactiveSystemFun(Contexts contexts) {
            
            Add(new GamePlayHumanSkillSystem(contexts));
            Add(new GameStartSystem(contexts));
            Add(new GamePauseSystem(contexts));
            Add(new GameEndSystem(contexts));
            Add(new JudgeHumanSkillSystem(contexts));
            
            Behaviour(contexts);
        }

        private void Behaviour(Contexts contexts) {
            //enter
            Add(new GameEnterIdelStateSystem(contexts));
            Add(new GameEnterWalkStateSystem(contexts));
            Add(new GameEnterAttackStateSystem(contexts));
            //update
            Add(new GameUpdateMoveStateSystem(contexts));
        }
    }
}
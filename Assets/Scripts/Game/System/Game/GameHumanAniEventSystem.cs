using System.Collections.Generic;
using System.Threading.Tasks;
namespace Game {
    using System;

    using Entitas;
    using UnityEngine;

    /// <summary>
    /// 为ICustomAniEventManager添加代理，当animator状态发生改变时，更新humanBehaviorState;
    /// </summary>
    public class GameHumanAniEventSystem : IInitializeSystem {
        protected Contexts _contexts;
        public GameHumanAniEventSystem(Contexts contexts) {
            _contexts = contexts;
        }

        public async void Initialize() {
            await Task.Delay(800);
            ICustomAniEventManager manager = _contexts.game.gamePlayer.Ani.AniEventManager;
            manager.AddEventListener(Enter, Update, Exit);

        }

        private void Enter(string name) {
            ReplaceData(name, BehaviorState.ENTER);
        }

        private void Update(string name) {
            ReplaceData(name, BehaviorState.UPDATE);
        }

        private void Exit(string name) {
            ReplaceData(name, BehaviorState.EXIT);
        }

        private void ReplaceData(string name, BehaviorState state) {
            foreach (PlayerBehaviourIndex behaviourIndex in Enum.GetValues(typeof(PlayerBehaviourIndex))) {
                ReplaceData(name, behaviourIndex, state);
            }
        }

        private void ReplaceData(string name, PlayerBehaviourIndex behavior, BehaviorState state) {
            string key = behavior.ToString().ToLower();
            if (name.Contains(key)) {
                Debug.Log("ReplaceData:" +behavior);
                _contexts.game.ReplaceGameHumanBehaviourState(behavior, state);
            }
        }

    }
}
using System.Collections.Generic;

using Entitas;

using UnityEngine;

namespace Game {

    public class SkillManagerSystem : IInitializeSystem, IGameAnyValidHumanSkillListener, IGameAnyEndHumanSkillListener {
        protected Contexts _contexts;
        private Queue<int> _codeCache;
        //缓存指令最大数量
        private int _cacheLengthMax;
        private int _currentPlayingCode;

        public SkillManagerSystem(Contexts context) {
            _contexts = context;
            _codeCache = new Queue<int>();
            _cacheLengthMax = 2;
        }

        public void Initialize() {
            var entity = _contexts.game.CreateEntity();
            entity.AddGameAnyValidHumanSkillListener(this);
            entity.AddGameAnyEndHumanSkillListener(this);
        }

        public void OnGameAnyEndHumanSkill(GameEntity entity, int skillCode) {
            Debug.Log("_currentPlayingCode == skillCode" + ( _currentPlayingCode == skillCode));
            if (_currentPlayingCode == skillCode) {
                bool playFailed = !PlaySkill();
                if (playFailed) {
                    Debug.Log("OnGameAnyEndHumanSkill playFailed" );
                    _contexts.game.ReplaceGamePlayHumanSkill(0);
                }
            }
        }

        public void OnGameAnyValidHumanSkill(GameEntity entity, int skillCode) {
            AddCode(skillCode);
            if (!_contexts.game.gamePlayer.Behavior.IsAttack) {
                PlaySkill();
            }
        }

        private bool PlaySkill() {
            if (_codeCache.Count <= 0) {
                return false;
            }
            
            int code = _codeCache.Dequeue();
            _currentPlayingCode = code;
            _contexts.game.ReplaceGamePlayHumanSkill(_currentPlayingCode);
            Debug.Log("playSkillll:" + code);
            return true;

        }

        private void AddCode(int skillCode) {
            Debug.Log("addCode:"+ skillCode);
            if (_codeCache.Count < _cacheLengthMax) {
                _codeCache.Enqueue(skillCode);
            }
        }
    }

}
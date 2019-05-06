using System.Collections.Generic;
using System.Linq;
using Entitas;
using Model;
using UnityEngine;

namespace Game {
    /// <summary>
    /// 判断技能按钮输入的是否有效
    /// </summary>
    /// <typeparam name="InputEntity"></typeparam>
    public class JudgeHumanSkillSystem : ReactiveSystem<InputEntity> {
        protected Contexts _contexts;

        public JudgeHumanSkillSystem(Contexts contexts) : base(contexts.input) {
            _contexts = contexts;

        }

        protected override void Execute(List<InputEntity> entities) {
            foreach (InputEntity entity in entities)
            {
                int code = entity.gameInputHumanSkillState.SkillCode;
                code = GetValidCode(code);
                entity.ReplaceGameInputHumanSkillState(false, 0);
                _contexts.game.ReplaceGameValidHumanSkill(code);
                Debug.Log("JudgeHumanSkillSystem ValidHumanSkill:" + code);
            }
        }

        protected override bool Filter(InputEntity entity) {
            return entity.hasGameInputHumanSkillState &&
                entity.gameInputHumanSkillState.IsEnd;
        }

        protected override ICollector<InputEntity> GetTrigger(IContext<InputEntity> context) {
            return context.CreateCollector(InputMatcher.GameInputHumanSkillState);
        }

        private int GetValidCode(int code) {
            if (JudgeIsValidCode(code)) {
                return code;
            } else {
                return GetLongValidCode(code);
            }
        }

        private int GetLongValidCode(int code) {
            string codeString = code.ToString();
            codeString = codeString.Remove(codeString.Length - 1, 1);
            return GetValidCode(int.Parse(codeString));
        }

        private bool JudgeIsValidCode(int code) {
            return GetValidData().Any(u => u.Code == code);
        }
        private List<ValidHumanSkill> GetValidData() {
            return _contexts.game.gameHumanSkillConfig.ValidHumanSkills;
        }
    }
}
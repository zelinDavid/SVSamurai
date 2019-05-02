using System.Collections.Generic;
using Entitas;
using Game.Service;

namespace Game {
    /*
       filter: attact_x || attact_0

       //player.ani.attack();
       player.behavior.attack();
       animator绑定对应的组件;
       自定义的timer,增加skill.


     */
    //TODO: 上次写到这里

    public class InputHumanSkillStateSystem : ReactiveSystem<InputEntity>, IInitializeSystem {
        Contexts _contexts;
        public InputHumanSkillStateSystem(Contexts contexts) : base(contexts.input) {
            _contexts = contexts;
        }

        public void Initialize() {
            _contexts.input.ReplaceGameInputHumanSkillState(false, 0);
        }

        protected override void Execute(List<InputEntity> entities) {
            foreach (InputEntity entity in entities) {
                //TODO:这个地方逻辑没有搞清楚
                ITimerService timerService = _contexts.service.gameServiceTimerService.TimerService;
                var timer = timerService.CreatOrRestartTimer(TimerId.JUDGE_SKILL_TIMER, 0.2f, false);
                timer.AddCompleteListener(() => SetValid(entity, true));
                SetValid(entity, false);
            }
        }

        private void SetValid(InputEntity entity, bool isValid) {
            var skillComponent = _contexts.input.gameInputHumanSkillState;
            ReplaceValidHumanSkil(entity, isValid, skillComponent);
        }

        private void ReplaceValidHumanSkil(InputEntity entity, bool isValid, InputHumanSkillState skill) {
            int code = 0;
            if (skill != null) {
                code = skill.SkillCode;
            }

            if (!isValid) {
                isValid = JudgeLength(code);
            }
            if (!isValid) {
                code = _contexts.service
                    .gameServiceSkillCodeService.SkillCodeService.GetCurrentSkillcode(entity.gameInputButton.InputButton, code);
            }

            if (isValid)
            {
                ITimerService timerService = _contexts.service.gameServiceTimerService.TimerService;
                timerService.StopTimer(timerService.GeTimer(TimerId.JUDGE_SKILL_TIMER) , false);
            }
            _contexts.input.ReplaceGameInputHumanSkillState(isValid, code);
        }

        private bool JudgeLength(int code) {
            int max = _contexts.game.gameHumanSkillConfig.LengthMax;
            return code.ToString().Length == max;

        }

        protected override bool Filter(InputEntity entity) {
            return entity.gameInputButton.InputButton == InputButton.ATTACK_O ||
                entity.gameInputButton.InputButton == InputButton.ATTACK_X;
        }

        protected override ICollector<InputEntity> GetTrigger(IContext<InputEntity> context) {
            return context.CreateCollector(InputMatcher.GameInputButton);
        }
    }

}
using System.Collections.Generic;

using UnityEngine;

namespace Game {
    public class InputNullSystem : InputButtonSystemBase {
        public InputNullSystem(Contexts contexts) : base(contexts) { }

        protected override void Execute(List<InputEntity> entities) {
            var timer = _contexts.service.gameServiceTimerService.TimerService.GeTimer(TimerId.MOVE_TIMER);
             timer?.Stop(true);

            if (_contexts.game.hasGamePlayer) {
                _contexts.game.gamePlayer.Ani.Idle();
                _contexts.game.gamePlayer.Ani.IsRun = false;
                _contexts.game.gamePlayer.Audio.IsRun = false;
            }
           
            //TODO: 自定义模块的timer调用.
            // Debug.Log("InputNullSystem");
        }

        protected override bool Filter(InputEntity entity) {
            return entity.hasGameInputButton && entity.gameInputButton.InputState == InputState.NULL;
        }

        protected override bool FilterCondition(InputEntity entity) {
            return true;
        }
    }

    /// <summary>
    /// 向前按键响应系统
    /// </summary>
    public class InputForwardButtonSystem : InputPressButtonSystemBase {
        public InputForwardButtonSystem(Contexts contexts) : base(contexts) { }

        protected override bool FilterCondition(InputEntity entity) {
            return entity.gameInputButton.InputButton == InputButton.FORWARD;
        }

        protected override void Execute(List<InputEntity> entities) {
            (_contexts.game.gamePlayer.Behavior as PlayerBehaviour).TurnForward();
            //TODO:播放ani动画
            (_contexts.game.gamePlayer.Ani as PlayerAni).Move();

            // Debug.Log("InputForwardButtonSystem");
        }

    }

    /// <summary>
    /// 向后按键响应系统
    /// </summary>
    public class InputBackButtonSystem : InputPressButtonSystemBase {
        public InputBackButtonSystem(Contexts contexts) : base(contexts) { }

        protected override bool FilterCondition(InputEntity entity) {
            return entity.gameInputButton.InputButton == InputButton.BACK;
        }

        protected override void Execute(List<InputEntity> entities) {
            _contexts.game.gamePlayer.Behavior.TurnBack();
            _contexts.game.gamePlayer.Ani.Move();
            // Debug.Log("InputBackButtonSystem");

        }
    }

    /// <summary>
    /// 向左按键响应系统
    /// </summary>
    public class InputLeftButtonSystem : InputPressButtonSystemBase {
        public InputLeftButtonSystem(Contexts contexts) : base(contexts) { }

        protected override bool FilterCondition(InputEntity entity) {
            return entity.gameInputButton.InputButton == InputButton.LEFT;
        }

        protected override void Execute(List<InputEntity> entities) {
            _contexts.game.gamePlayer.Behavior.TurnLeft();
            _contexts.game.gamePlayer.Ani.Move();
            // Debug.Log("InputLeftButtonSystem");

        }
    }

    /// <summary>
    /// 向右按键响应系统
    /// </summary>
    public class InputRightButtonSystem : InputPressButtonSystemBase {
        public InputRightButtonSystem(Contexts contexts) : base(contexts) { }

        protected override bool FilterCondition(InputEntity entity) {
            return entity.gameInputButton.InputButton == InputButton.RIGHT;
        }

        protected override void Execute(List<InputEntity> entities) {
            _contexts.game.gamePlayer.Behavior.TurnRight();
            _contexts.game.gamePlayer.Ani.Move();
            // Debug.Log("InputRightButtonSystem");

        }
    }

    /// <summary>
    /// 移动部分响应系统
    /// </summary>
    public class InputMoveButtonSystem : InputDownButtonSystemBase {
        public InputMoveButtonSystem(Contexts contexts) : base(contexts) { }

        protected override bool FilterCondition(InputEntity entity) {
            return entity.gameInputButton.InputButton == InputButton.LEFT ||
                entity.gameInputButton.InputButton == InputButton.RIGHT ||
                entity.gameInputButton.InputButton == InputButton.FORWARD ||
                entity.gameInputButton.InputButton == InputButton.BACK;
        }

        protected override void Execute(List<InputEntity> entities) {
            var service = _contexts.service.gameServiceTimerService.TimerService.CreateTimer(TimerId.MOVE_TIMER, 1, false);
            // Debug.Log("serviceExecute:" + service);
            if (service != null)
            {
                service.AddCompleteListener(()=> {
                    _contexts.game.gamePlayer.Ani.IsRun = true;
                    _contexts.game.gamePlayer.Audio.IsRun = true;
                    // Debug.Log("timeService listen complete");

                });
            }
            // Debug.Log("InputMoveButtonSystem");
        }
    }

}
using System.Collections.Generic;

using Entitas;

namespace Game {
    public abstract class InputButtonSystemBase : ReactiveSystem<InputEntity> {
        protected Contexts _contexts;
        protected InputButtonSystemBase(Contexts contexts) : base(contexts.input) {
            _contexts = contexts;
        }

        protected override bool Filter(InputEntity entity) {
            return entity.hasGameInputButton && FilterCondition();
        }

        protected override ICollector<InputEntity> GetTrigger(IContext<InputEntity> context) {
            return context.CreateCollector(InputMatcher.GameInputButton);
        }
        /// <summary>
        /// 事件执行的筛选条件
        /// </summary>
        /// <returns></returns>
        protected abstract bool FilterCondition();
    }

    /// <summary>
    /// 按下响应系统基类
    /// </summary>
    public abstract class InputDownButtonSystemBase : InputButtonSystemBase {
        protected InputDownButtonSystemBase(Contexts contexts) : base(contexts) { }

        protected override bool Filter(InputEntity entity) {
            return base.Filter(entity) && entity.gameInputButton.InputState == InputState.DOWN;
        }

    }

    /// <summary>
    /// 持续按下响应系统基类
    /// </summary>
    public abstract class InputPressButtonSystemBase : InputButtonSystemBase
    {
        public InputPressButtonSystemBase(Contexts contexts) : base(contexts)
        {
        }

        protected override bool Filter(InputEntity entity)
        {
            return base.Filter(entity) && entity.gameInputButton.InputState == InputState.PREE;
        }
    }

    /// <summary>
    /// 抬起响应系统基类
    /// </summary>
    public abstract class InputUpButtonSystemBase : InputButtonSystemBase
    {
        public InputUpButtonSystemBase(Contexts contexts) : base(contexts)
        {
        }

        protected override bool Filter(InputEntity entity)
        {
            return base.Filter(entity) && entity.gameInputButton.InputState == InputState.UP;
        }
    }

}
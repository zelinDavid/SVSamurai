//看一个文件， 自己写这个文件，最后更改名称

using System.Collections.Generic;

namespace Game
{
    public class InputNullHumanSystem : InputButtonSystemBase
    {
        public InputNullHumanSystem(Contexts contexts) : base(contexts)
        {
        }

        protected override void Execute(List<InputEntity> entities)
        {
            if (_contexts.game.hasGamePlayer)
            {
                _contexts.game.gamePlayer.Ani.Idle();
                _contexts.game.gamePlayer.Ani.IsRun = false;
                _contexts.game.gamePlayer.Audio.IsRun = false;
            }
        }

         protected override bool Filter(InputEntity entity) {
            return entity.gameInputButton.InputButton == InputButton.NULL && entity.gameInputButton.InputState == InputState.NULL;
        }

        protected override bool FilterCondition(InputEntity entity)
        {
            return true;
        }
    }
}



















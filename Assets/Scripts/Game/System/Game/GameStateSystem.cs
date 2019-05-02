using System.Collections.Generic;
using Entitas;

namespace Game
{
    /// <summary>
    /// ��Ϸ״̬����ϵͳ����
    /// </summary>
    public abstract class GameStateSystemBase : ReactiveSystem<GameEntity>
    {
        protected Contexts _contexts;

        public GameStateSystemBase(Contexts context) : base(context.game)
        {
            _contexts = context;
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(GameMatcher.GameGameState);
        }

        protected override bool Filter(GameEntity entity)
        {
            return entity.hasGameGameState && FilterCondition(entity);
        }

        protected abstract bool FilterCondition(GameEntity entity);
    }

    /// <summary>
    /// ��Ϸ��ʼ��Ӧ�¼�
    /// </summary>
    public class GameStartSystem : GameStateSystemBase
    {
        public GameStartSystem(Contexts context) : base(context)
        {
        }

        protected override bool FilterCondition(GameEntity entity)
        {
            return entity.gameGameState.GameState == GameState.START;
        }

        protected override void Execute(List<GameEntity> entities)
        {
            _contexts.game.ReplaceGameCameraState(CameraAniName.START_GAME_ANI);
        }
    }

    /// <summary>
    /// ��Ϸ��ͣ��Ӧ�¼�
    /// </summary>
    public class GamePauseSystem : GameStateSystemBase
    {
        public GamePauseSystem(Contexts context) : base(context)
        {
        }

        protected override bool FilterCondition(GameEntity entity)
        {
            return entity.gameGameState.GameState == GameState.PAUSE;
        }

        protected override void Execute(List<GameEntity> entities)
        {
            throw new System.NotImplementedException();
        }
    }

    /// <summary>
    /// ��Ϸ������Ӧ�¼�
    /// </summary>
    public class GameEndSystem : GameStateSystemBase
    {
        public GameEndSystem(Contexts context) : base(context)
        {
        }

        protected override bool FilterCondition(GameEntity entity)
        {
            return entity.gameGameState.GameState == GameState.END;
        }

        protected override void Execute(List<GameEntity> entities)
        {
            throw new System.NotImplementedException();
        }
    }
}

using System.Collections.Generic;
using Entitas;
using UnityEngine;

namespace Game
{
    public class GamePlayHumanSkillSystem : ReactiveSystem<GameEntity>
    {
        protected Contexts _contexts;
        public GamePlayHumanSkillSystem(Contexts contexts) : base(contexts.game)
        {
            _contexts = contexts;
        }

        protected override void Execute(List<GameEntity> entities)
        {
            foreach (GameEntity entity in entities)
            {
                var code = entity.gamePlayHumanSkill.SkillCode;

                //code为0时，代表重置
                //code大于0时，才是正确的执行编码
                Debug.Log("GamePlayHumanSkillSystem attackCode:" + code);
                _contexts.game.gamePlayer.Ani.Attack(code);
                if (code > 0)
                {
                    _contexts.game.gamePlayer.Audio.Attack(code);
                    _contexts.game.gamePlayer.Behavior.Attack(code);
                }
            }
        }

        protected override bool Filter(GameEntity entity)
        {
           return entity.hasGamePlayHumanSkill ;
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(GameMatcher.GamePlayHumanSkill);
        }
    }
}
using System.Security.Cryptography.X509Certificates;

using Entitas;
using Entitas.CodeGeneration.Attributes;

using UnityEngine;

namespace Game {
    /// <summary>
    /// 摄像机状态组件
    /// </summary>
    [Game, Event(EventTarget.Self), Unique]
    public class CameraState : IComponent {
        public CameraAniName state;
    }

    [Game, Unique]
    public class PlayerComponent : IComponent {
        public IView Player;
        public IPlayerBehaviour Behavior;
        public IPlayerAni Ani;
        public IPlayerAudio Audio;
    }

    [Game, Unique]
    public class HumanBehaviourStateComponent : IComponent {
        public PlayerBehaviourIndex Behaviour;
        public BehaviorState State;
    }

    /// <summary>
    /// 玩家动画
    /// </summary>
    [Game]
    public class PlayerAniState : IComponent {
        public PlayerAniIndex AniIndex;
    }

    /// <summary>
    /// 人物技能开始事件
    /// </summary>
    [Game, Unique, Event(EventTarget.Any)]
    public class StartHumanSkillComponent : IComponent {
        /// <summary>
        /// 技能编码
        /// </summary>
        public int SkillCode;
    }

    /// <summary>
    /// 人物技能结束事件
    /// </summary>
    [Game, Unique, Event(EventTarget.Any)]
    public class EndHumanSkillComponent : IComponent {
        /// <summary>
        /// 技能编码
        /// </summary>
        public int SkillCode;
    }

    /// <summary>
    /// 游戏状态
    /// </summary>
    [Game, Unique]
    public class GameStateComponent : IComponent {
        public GameState GameState;
    }

}
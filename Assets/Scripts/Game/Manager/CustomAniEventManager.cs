using System;
using System.Collections.Generic;

using UnityEditor.Animations;

using UnityEngine;

/*
    Animator动画切换逻辑：
        AniIndex 控制动画切换：idle -> walk -> run
        AniIndex不变的情况下，改变 skill，变为放技能的状态





 */
namespace Game {
    public interface ICustomAniEventManager {
        void AddEventListener(Action<string> OnStateEnterAction, Action<string> OnStateUpdateAction, Action<string> OnStateExitAction);

    }

    public class CustomAniEventManager : ICustomAniEventManager {
        //TODO：你上次写到这里；
        /*
        ICustomAniEventManager  AddEventListener  action entryState updateState existState
        CustomAniEventManager
            构造函数； SkillCodeModule skill与code转化；
 
         */
        private Dictionary<PlayerAniStateName, AnimatorState> _statesDic;
        private Dictionary<PlayerAniStateName, CustomAniEvent> _eventDic;
        private Animator _animator;
        public CustomAniEventManager(Animator animator) {
            _animator = animator;

            _statesDic = new Dictionary<PlayerAniStateName, AnimatorState>();
            _eventDic = new Dictionary<PlayerAniStateName, CustomAniEvent>();

            new InitSkillAni(animator);
            InitAnimatorStateData(animator);
            AddCustomAniEventScripts();
            InitCustomAniEventScripts();
        }

        private void InitAnimatorStateData(Animator animator) {
            AnimatorController aniController = _animator.runtimeAnimatorController as AnimatorController;
            foreach (ChildAnimatorState animatorState in aniController.layers[0].stateMachine.states) {
                foreach (PlayerAniStateName stateName in Enum.GetValues(typeof(PlayerAniStateName))) {
                    if (animatorState.state.name == stateName.ToString()) {
                        _statesDic.Add(stateName, animatorState.state);
                    }
                }
                if (!_statesDic.ContainsValue(animatorState.state)) {
                    Debug.LogError("animatorState fail");
                }
            }
        }

        private void AddCustomAniEventScripts() {
            CustomAniEvent behaviorTemp;
            foreach (KeyValuePair<PlayerAniStateName, AnimatorState> pair in _statesDic) {
                behaviorTemp = null;
                foreach (var behavior in pair.Value.behaviours) {
                    if (behavior is CustomAniEvent) {
                        behaviorTemp = behavior as CustomAniEvent;
                        break;
                    }
                }
                if (behaviorTemp == null) {
                    _eventDic[pair.Key] = pair.Value.AddStateMachineBehaviour<CustomAniEvent>();
                } else {
                    _eventDic[pair.Key] = behaviorTemp;
                }
            }
        }

        public void AddEventListener(Action<string> OnStateEnterAction, Action<string> OnStateUpdateAction, Action<string> OnStateExitAction) {
            foreach (CustomAniEvent aniEvent in _animator.GetBehaviours<CustomAniEvent>()) {
                aniEvent.OnStateEnterAction = OnStateEnterAction;
                aniEvent.OnStateUpdateAction = OnStateUpdateAction;
                aniEvent.OnStateExitAction = OnStateExitAction;
            }
        }

        private void InitCustomAniEventScripts()
        {
            foreach (KeyValuePair<PlayerAniStateName, CustomAniEvent> pair in _eventDic)
            {
                pair.Value.Init(pair.Key);
            }
        }
    }


    /// <summary>
    /// 技能脚本名称初始化
    /// </summary>
    public class InitSkillAni {
        public InitSkillAni(Animator animator) {
            SetStateName(animator);
        }

        private void SetStateName(Animator animtor) {

        }
    }

    /// <summary>
    /// 角色动画名称
    /// </summary>
    public enum PlayerAniStateName {
        idle,
        walk,
        run,
        idleSword,
        walkSword,
        runSword
    }

}
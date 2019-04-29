using System;

using Game;

using UnityEngine;

/// <summary>
/// 自定义动画事件代理
/// </summary>
public class CustomAniEvent : StateMachineBehaviour {
    public Action<string> OnStateEnterAction;
    public Action<string> OnStateUpdateAction;
    public Action<string> OnStateExitAction;

    public void Init(PlayerAniStateName stateName) {
        name = stateName.ToString();
    }

    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
        OnStateEnterAction?.Invoke(name);
    }

    public override void OnStateUpdate(Animator animator, AnimatorStateInfo animatorStateInfo, int layerIndex) {
        OnStateUpdateAction?.Invoke(name);
    }

    public override void OnStateExit(Animator animator, AnimatorStateInfo animatorStateInfo, int layerIndex) {
        OnStateExitAction?.Invoke(name);
    }
}
using System;

using UnityEngine;

public class SkillAniState : StateMachineBehaviour {
    private int _code = -1;
    private bool _checkState;

    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
        Debug.Log("onStateEnter name:" + name);

        if (_code < 0) {
            try {
                string code = name.Remove(name.Length - 7, 7);
                _code = int.Parse(code);
            } catch (System.Exception) {
                Debug.LogError("转换机能编码错误");
                _code = 0;
            }
        }
        if (typeof(Contexts) != null) {
            Contexts.sharedInstance.game.ReplaceGameStartHumanSkill(_code);

        }
    }

    public override void OnStateUpdate(Animator animator, AnimatorStateInfo animatorStateInfo, int layerIndex) {
        if (Contexts.sharedInstance.game.gamePlayHumanSkill.SkillCode != 0) {
            Contexts.sharedInstance.game.ReplaceGamePlayHumanSkill(0);
        }

    }
    public override void OnStateExit(Animator animator, AnimatorStateInfo animatorStateInfo, int layerIndex) {
        if (_code >= 0 && typeof(Contexts) != null) {
            Contexts.sharedInstance.game.ReplaceGameEndHumanSkill(_code);
        }

    }

}
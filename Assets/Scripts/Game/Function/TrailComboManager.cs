using System.Collections.Generic;
using System;
using Entitas;
using UnityEngine;
using Module;
using Const;

namespace Game.View {
    /*
        控制播放特效，命名更适合使用 TrailComboView
        Trail 轨迹，踪迹
        监听技能播放开始时， 播放对应的特效

     */
    public class TrailComboManager : ViewBase, IGameAnyStartHumanSkillListener {
        private string _prefixName = "trail_";
        private Dictionary<int,TrailsEffect> _trailsDic;
        private Dictionary<int, float> _clipLengthDic;
        private SkillCodeModule _module;

        public override void Init(Contexts contexts, IEntity entity){
            base.Init(contexts, entity);
            _entity.AddGameAnyStartHumanSkillListener(this);

            _trailsDic = new Dictionary<int, TrailsEffect>();
            _clipLengthDic = new Dictionary<int, float>();
            _module = new SkillCodeModule();
        }

 
        public void Init(Contexts contexts, IEntity entity,Animator animator){
            Init(contexts,entity);
            InitClipLengthDic(animator);
            InitTrailsDic();
            //TODO:你上次写到这里
        }

        private void InitTrailsDic(){
            int code = 0;
            float length = 0;

            foreach (Transform  childTran in transform)
            {
                code = GetSkillCode(childTran.name);
                if (_clipLengthDic.ContainsKey(code))
                {
                    length = _clipLengthDic[code];
                    _trailsDic[code] = childTran.gameObject.AddComponent<TrailsEffect>();
                   _trailsDic[code].Init(length);
                }else {
                    Debug.LogError("未发现对应的技能特效：" + childTran.name);

                   _trailsDic[code] = childTran.gameObject.AddComponent<TrailsEffect>();
                   _trailsDic[code].Init(0);
                }
            }
        }

        private int GetSkillCode(string skilName){

            return  _module.GetSkillCode(skilName,_prefixName, "");
        }
        

        private void InitClipLengthDic(Animator animator){
            var clips = animator.runtimeAnimatorController.animationClips;
            int code = 0;

            foreach (AnimationClip clip in clips)
            {
                Debug.Log("clipName:" + clip.name);
                code = _module.GetSkillCode(clip.name, ConstValue.SKILL_ANI_PREFIX, "");
                if (code < 0)
                {
                    continue;
                }
                _clipLengthDic.Add(code, clip.length);
            }
        }

        public void OnGameAnyStartHumanSkill(GameEntity entity, int skillCode) {
            throw new System.NotImplementedException();
        }
    }
}
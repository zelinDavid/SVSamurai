using System.Collections.Generic;

using Const;

using Entitas;

using Game.Service;

using Manager;
using Game.View.Effect;
using Module;
using Module.Timer;

namespace Game.View {
    public class HumanSkillView : ViewBase, IGameAnyPlayHumanSkillListener {
        // private List<human>
        private List<HumanSkillItem> _itemList;
        private SkillCodeModule _codeMoudle;
        private float _effectDuration;
        private ITimerService _timerService;

        private ITimer _timer;

        //绑定humanskill组件，播放技能事件

        //增加点难度， 自己来写;可以按自己的思路实现，再对比差异

        //预加载item;
        /*
        当skill改变时，展示对应的item；
        1s后消失
            
         */
        public override void Init(Contexts contexts, IEntity entity) {
            base.Init(contexts, entity);

            _entity.AddGameAnyPlayHumanSkillListener(this);

            _codeMoudle = new SkillCodeModule();
            _timerService = contexts.service.gameServiceTimerService.TimerService;

            PreLoadItem();
        }

        private void PreLoadItem() {
            var lengthMax = _contexts.game.gameHumanSkillConfig.LengthMax;
            _itemList = new List<HumanSkillItem>();
            for (int i = 0; i < lengthMax; i++) {
                var skillItem = LoadManager.Single.LoadAndInstaniate(Const.Path.HUMAN_SKILL_ITEM_UI_PATH, transform);
                HumanSkillItem item = skillItem.AddComponent<HumanSkillItem>();
                item.Init();
                _itemList.Add(item);
            }
        }

        public void OnGameAnyPlayHumanSkill(GameEntity entity, int skillCode) {
            ShowItems(skillCode);
            
        }

        private void StartTimer(){
            _timer = _timerService.CreatOrRestartTimer(TimerId.SKILL_VIEW, 1, false);
            _timer.AddCompleteListener(HideItems);
        }

        public void HideItems(){
            foreach (var item in _itemList)
            {
                 //TODO:上次写到这里
            }
             
        }

        public void ShowItems(int skillCode) {
            string codeStr = skillCode.ToString();
            for (int i = 0; i < codeStr.Length; i++) {
                _itemList[i].ShowWithCode(codeStr[i].ToString());
                _itemList[i].gameObject.ShowAllImageEffect(1);
            }
        }

    }
}
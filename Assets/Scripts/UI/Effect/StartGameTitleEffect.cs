namespace UIFrame {
    using Const;
    using DG.Tweening;
    using UnityEngine;
    using Util;

    public class StartGameTitleEffect : UIEffectBase {
        public override void Exist () {
             transform.RectTransform().DOAnchorPos(_defaultAncherPos, 1);
        }

        public override void Enter() {
            base.Enter();
            Debug.Log("StartGameTitleEffect Enter");
            transform.RectTransform().DOAnchorPosX(0, 1);
        }

        public override UiEffect GetEffectLevel () {
            return UiEffect.OTHERS_EFFECT;
        }
        
    }
}
using Const;
using DG.Tweening;
using UnityEngine;
using Util;

namespace UIFrame {

    public class StartGameButtonsEffect : UIEffectBase {
        public override void Exist () {
              transform.RectTransform().DOAnchorPosX(_defaultAncherPos.x, 1);
        }

        public override void Enter () {
            base.Enter();
            transform.RectTransform().DOKill();
            transform.RectTransform().DOAnchorPosX(0, 1);
        }

        public override UiEffect GetEffectLevel () {
            return UiEffect.VIEW_EFFECT;
        }
    }
}
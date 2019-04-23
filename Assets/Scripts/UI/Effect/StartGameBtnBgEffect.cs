using Const;
using DG.Tweening;

namespace UIFrame
{
    public class StartGameBtnBgEffect : UIEffectBase
    {
        public override void Exist()
        {
            transform.DOScaleY(0, 0.5f);
        }

        public override void Enter() {
            base.Enter();
            transform.DOScaleY(1, 0.5f);

        }

        public override UiEffect GetEffectLevel()
        {
           return UiEffect.VIEW_EFFECT;
        }
    }
}
 
using Const;
using DG.Tweening;
using UnityEngine;
using Util;

namespace UIFrame
{
    public class GameNameEffect : UIEffectBase
    {
        public override void Enter(){
            base.Enter();

            float time = 1;
            transform.DOKill();
            transform.RectTransform().DOKill();
            transform.DOScale(Vector3.one * 2, 0.25f);
            transform.RectTransform().DOAnchorPos(_defaultAncherPos,time).OnComplete(()=>_onExitComplete?.Invoke());
            //TODO:playAudio

            // Invoke("Exist", 2f);
            // Debug.LogWarning("GameNameEffect enter");
        }

        public override void Exist()
        {
            float time = 1;
            transform.DOKill();
            transform.RectTransform().DOKill();
            transform.DOScale(Vector3.one * 1.5f, time);
            transform.RectTransform().DOAnchorPos(new Vector2(497f, 198f), time).OnComplete(() => _onEnterComplete?.Invoke());
 
        }

        public override UiEffect GetEffectLevel()
        {
           return UiEffect.VIEW_EFFECT;
        }
    }
}
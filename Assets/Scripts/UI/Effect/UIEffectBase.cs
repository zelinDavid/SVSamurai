using System;
using Const;
using UnityEngine;
using Util;

namespace UIFrame {

    public abstract class UIEffectBase : MonoBehaviour {
        protected Action _onEnterComplete;
        protected Action _onExitComplete;

        protected Vector2 _defaultAncherPos = Vector2.zero;

        public virtual void Enter() {
            if (_defaultAncherPos == Vector2.zero) {
                _defaultAncherPos = transform.RectTransform ().anchoredPosition;
            }
        }

        public abstract void Exist ();

        public virtual void OnEnterComplete (Action onEnterComplete) {
            _onEnterComplete = onEnterComplete;
        }
        public virtual void OnExitComplete (Action onExitComplete) {
            _onExitComplete = onExitComplete;
        }

        public abstract UiEffect GetEffectLevel ();

    }
}
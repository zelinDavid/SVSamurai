using System;
using Const;
using UnityEngine;

namespace UIFrame {
    public class UIEffectManager : MonoBehaviour {
        public void Show (Transform ui) {
            if (ui == null) {
                return;
            }

            foreach (UIEffectBase effectBase in ui.GetComponentsInChildren<UIEffectBase> (true)) {
                effectBase.Enter ();
            }
        }

        public void Hide (Transform ui) {
            if (ui == null) {
                return;
            }
            foreach (UIEffectBase effectBase in ui.GetComponentsInChildren<UIEffectBase> (true)) {
                effectBase.Exist ();
            }
        }

        public void ShowOthersEffect (Transform ui) {
            foreach (UIEffectBase effectBase in ui.GetComponentsInChildren<UIEffectBase> (true)) {
                if (effectBase.GetEffectLevel () == UiEffect.OTHERS_EFFECT)
                    effectBase.Enter ();
            }
        }

        public void HideOthersEffect (Transform ui) {
            foreach (UIEffectBase effectBase in ui.GetComponentsInChildren<UIEffectBase> (true)) {
                if (effectBase.GetEffectLevel () == UiEffect.OTHERS_EFFECT)
                    effectBase.Exist ();
            }
        }

        public void AddViewEffectEnterListener (Transform ui, Action enterComplete) {
            foreach (UIEffectBase item in ui.GetComponentsInChildren<UIEffectBase> (true)) {
                if (item.GetEffectLevel () == UiEffect.VIEW_EFFECT) {
                    item.OnEnterComplete (enterComplete);
                }

            }
        }

        public void AddViewEffectExitListener (Transform ui, Action exitComplete) {
            foreach (UIEffectBase effectBase in ui.GetComponentsInChildren<UIEffectBase> (true)) {
                if (effectBase.GetEffectLevel () == UiEffect.VIEW_EFFECT) {
                    effectBase.OnExitComplete (exitComplete);
                }
            }
        }

    }
}
using System.Net.Mime;

using DG.Tweening;

using UnityEngine;
using UnityEngine.UI;

using Util;

namespace Game.View.Effect {
    public static class ShowHideEffect {
        public static void ShowAllImageEffect(this GameObject go, float duration) {
            var image = go.GetComponent<Image>();
            if (image.UtilDebugLogNull()) {
                return;
            }
            KillImageEffect(image);
            image.DOFade(1, duration);
        }

        public static void HideAllImageEffect(this GameObject go, float duration) {
            foreach (Image image in go.GetComponentsInChildren<Image>()) {
                KillImageEffect(image);
                image.DOFade(0, duration);
            }
        }

        private static void KillImageEffect(Image image) {
            image.DOKill();
        }
    }
}
using System;
using System.Net.Mime;
namespace Game.View {
    using Module;

    using UnityEngine.UI;
    using UnityEngine;

    /*
    控制gameObject显示或隐藏；
    改变显示动画
     */
    public class HumanSkillItem : MonoBehaviour {
        private HumanSkillSprite _spirtes;
        private Image _image;

        public void Init() {
            _spirtes = GetComponent<HumanSkillSprite>();
            _image = GetComponent<Image>();
            Show(false);
        }

        public void ShowWithCode(string code) {
            var spirte = GetSpriteByCode(code);
            if (spirte != null) {
                Show(true);
                ChangeSprite(spirte);
            } else {
                Show(false);
            }
        }

        public void ChangeSprite(Sprite sprite) {
            _image.sprite = sprite;
        }

        private Sprite GetSpriteByCode(string code) {
            if (SkillButton.O.ToString() == code) {
                return _spirtes.O;
            } else if (SkillButton.X.ToString() == code) {
                return _spirtes.X;
            }
            return null;
        }

        public void Show(bool isShow) {
            gameObject.SetActive(isShow);
        }

    }
}
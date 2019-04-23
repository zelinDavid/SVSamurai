using System;
using Const;
using UnityEngine;

namespace UIFrame {
    public class RootManager : MonoBehaviour {
        public static RootManager Instance { set; get; }

        protected UIManager _uiManager;
        protected UILayerManager _layManager;
        protected UIEffectManager _effectManager;

        private void Awake () {
            Instance = this;

            _uiManager = gameObject.AddComponent<UIManager> ();
            _layManager = gameObject.AddComponent<UILayerManager> ();

            _uiManager.AddGetLayerObjectListener (_layManager.GetLayerObject);
            _uiManager.AddInitCallBackListener ((uiTrans) => {
                
            });
            //实例化effectManager,在显示UI的时候，显示对应的effect;隐藏UI的时候隐藏对应的effect.
            _effectManager = gameObject.AddComponent<UIEffectManager>();
            
        }

        private void Start () {
            Show (UiId.MainMenu);
        }

        public void Show (UiId id) {
            var uiPara = _uiManager.Show(id);
            ExcuteEffect (uiPara);

            // ShowBtnState(uiPara.Item1);
        }

        public void Back () {
            var uiPara = _uiManager.Back ();
            ExcuteEffect (uiPara);
             
        }

        
        private void ExcuteEffect (Tuple<Transform, Transform> uiPara) {
            ShowUI (uiPara.Item1);
            HideUI (uiPara.Item2);
        }

        private void ShowUI (Transform showUI) {
            ShowEffect (showUI);

        }

        private void HideUI (Transform showUI) {
            HideEffect (showUI);
        }

        private void ShowEffect (Transform ui) {
            if (ui == null) {
                _effectManager.Show (ui);
            } else {
                _effectManager.ShowOthersEffect (_uiManager.GetCurrentUiTrans());
            }
        }

        private void HideEffect (Transform ui) {
            if (ui == null) {
                _effectManager.HideOthersEffect (_uiManager.GetBaiscUiTrans ());
            } else { }
            _effectManager.Hide (ui);
        }

        public void GetCurrentTrans () {
            _uiManager.GetCurrentUiTrans ();
        }
    }
}
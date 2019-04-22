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
            _effectManager = gameObject.AddComponent<UIEffectManager> ();

        }

        private void Start () {

        }

        private void ShowEffect (Transform ui) {
            _effectManager.Show(ui);
            //TODO:老爷你上次写到这儿。。
        }

        private void HideEffect (Transform ui) {
            _effectManager.HideOthersEffect (ui);
        }

        public void GetCurrentTrans () {
            _uiManager.GetCurrentUiTrans();
        }
    }
}
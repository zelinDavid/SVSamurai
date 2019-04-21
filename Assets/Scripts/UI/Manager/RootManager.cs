using UnityEngine;

namespace UIFrame {
    public class RootManager : MonoBehaviour {
        public static RootManager Instance { set; get; }

        private UIManager _uiManager;
        private UILayerManager _layManager;

        private void Awake () {
            Instance = this;

            _uiManager = gameObject.AddComponent<UIManager> ();
            _layManager = gameObject.AddComponent<UILayerManager>();

            _uiManager.AddGetLayerObjectListener(_layManager.GetLayerObject);
            _uiManager.AddInitCallBackListener((uiTrans) => {
                
            });
        }

        private void Start () {

        }

       


    }
}
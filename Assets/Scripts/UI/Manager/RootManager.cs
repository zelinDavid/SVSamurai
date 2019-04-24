using System;

using Const;

using Manager;

using UnityEngine;

namespace UIFrame {
    public class RootManager : MonoBehaviour {
        public static RootManager Instance { set; get; }

        private UIManager _uiManager;
        private UILayerManager _layManager;
        private UIEffectManager _effectManager;
        private UIAudioManager _audioManager;
        private BtnStateManager _btnStateManager;
        private  InputManager _inputManager;

        private void Awake() {
            Instance = this;

            _audioManager = gameObject.AddComponent<UIAudioManager>();
            _uiManager = gameObject.AddComponent<UIManager>();
            _layManager = gameObject.AddComponent<UILayerManager>();
            _btnStateManager = gameObject.AddComponent<BtnStateManager>();
            _inputManager = gameObject.AddComponent<InputManager>();

            _uiManager.AddGetLayerObjectListener(_layManager.GetLayerObject);
            _uiManager.AddInitCallBackListener((uiTrans) => {
                var parents = _uiManager.GetBtnParents(uiTrans);
                _btnStateManager.InitBtnParent(parents);
            });

            //实例化effectManager,在显示UI的时候，显示对应的effect;隐藏UI的时候隐藏对应的effect.
            _effectManager = gameObject.AddComponent<UIEffectManager>();

            _audioManager.Init(Path.UI_AUDIO_PATH, LoadManager.Single.LoadAll<AudioClip>);
            _audioManager.PlayBg(UIAudioName.UI_bg.ToString());

        }

        private void Start() {
            Show(UiId.MainMenu);
        }

        public void Show(UiId id) {
            var uiPara = _uiManager.Show(id);
            ExcuteEffect(uiPara);
            ShowBtnState(uiPara.Item1);
 
        }

        public void Back() {
            var uiPara = _uiManager.Back();
            ExcuteEffect(uiPara);
            ShowBtnState(_uiManager.GetCurrentUiTrans());

        }

        private void ExcuteEffect(Tuple<Transform, Transform> uiPara) {
            ShowUI(uiPara.Item1);
            HideUI(uiPara.Item2);
        }

        private void ShowUI(Transform showUI) {
            ShowEffect(showUI);
            ShowUIAudio();
        }

        private void HideUI(Transform showUI) {
            HideEffect(showUI);
            HideUIAudio();
        }

        private void ShowEffect(Transform ui) {
            Debug.LogWarning("showEffect:" + ui);
            if (ui == null) {
                _effectManager.ShowOthersEffect(_uiManager.GetCurrentUiTrans());
            } else {
                _effectManager.Show(ui);
            }
        }

        private void HideEffect(Transform ui) {
            if (ui == null) {
                _effectManager.HideOthersEffect(_uiManager.GetBaiscUiTrans());
            } else { }
            _effectManager.Hide(ui);
        }

        public void GetCurrentTrans() {
            _uiManager.GetCurrentUiTrans();
        }

        private void ShowUIAudio() {
            _audioManager.Play(UIAudioName.UI_in.ToString());
        }

        private void HideUIAudio() {
            _audioManager.Play(UIAudioName.UI_out.ToString());
        }

        public void PlayAudio(UIAudioName name) {
            _audioManager.Play(name.ToString());
        }

        #region  btnState相关
        public void ButtonLeft() {
            _btnStateManager.Left();
        }

        public void ButtonRight() {
            _btnStateManager.Right();
        }

        public void SelectedButton() {
            _btnStateManager.SelectedButton();
        }

        private void ShowBtnState(Transform ui) {
            _btnStateManager.Show(ui);
        }

        #endregion

    }
}
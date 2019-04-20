using System.Collections.Generic;
using Const;
using UnityEngine;

namespace UIFrame {
    public abstract class UIBase : MonoBehaviour {
        private UIState _uiState = UIState.NORMAL;
        public UIState UiState {
            get { return _uiState; }

            set {

                _uiState = value;
            }
        }

        private void HandleUiState (UIState value) {
            switch (value) {
                case  UIState.INIT:
                    if (value == UIState.NORMAL)
                    {
                        Init();
                    }
                    break;
                case  UIState.SHOW:
                     if (value == UIState.NORMAL)
                    {
                        Init();
                        Show();
                    }else{
                        Show();
                    }
                    break;
                case  UIState.HIDE:
                    Hide();
                    break;
            }

        }

        protected virtual void Init(){

        }

        protected virtual void Show(){

        }

        protected virtual void Hide(){

        }

        protected virtual void SetActive (bool active) {
            gameObject.SetActive (active);
        }

        protected abstract UiId GetUiId ();

        public abstract List<Transform> GetBtnParents ();

        public abstract UILayer GetUiLayer ();
    }
}
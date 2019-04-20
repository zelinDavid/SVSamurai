using System;
using System.Collections.Generic;
using Const;
using Manager;
using UnityEngine;
using Util;

namespace UIFrame {
    public class UIManager : MonoBehaviour {
        private Dictionary<UiId, GameObject> _prefabDictionary = new Dictionary<UiId, GameObject> ();
        private Func<UILayer, Transform> GetLayerObject;
        private Action<Transform> InitCallBack;
        private Stack<UIBase> _uiStack = new Stack<UIBase> ();

        public Tuple<Transform, Transform> Show(UiId id){
            //根据id实例化对应的view.
            /*
                获取对应UIBase, initUI
                如果当前UI是baseUI，则隐藏当前的View
                push当前UI.'
                返回tuple,  ui.transform, hideUI
             */
           var prefab = GetPrefabObject(id);
            if (prefab == null)
            {
                Debug.LogError("can not find prefab "+ id);
                return null;
            }

            UIBase view = GetUIScript(prefab, id);
            if (view == null)
            {
                return null;
            }
            InitUi(view);

            Transform hideUI = null;
            if (view.GetUiLayer() == UILayer.BASIC_UI)
            {
                hideUI = Hide();
            }
             view.UiState = UIState.SHOW;

            return new Tuple<Transform,Transform>(prefab.transform,hideUI);
        }

        public Tuple<Transform, Transform> Back(){
            if (_uiStack.Count > 1)
            {
                Transform showView = null;
                UIBase hideView = _uiStack.Pop();
                if (hideView.GetUiLayer() == UILayer.BASIC_UI)
                {
                    _uiStack.Peek().UiState = UIState.SHOW;
                    showView = _uiStack.Peek().transform;
                    hideView.UiState = UIState.HIDE;
                }else{
                    hideView.UiState = UIState.HIDE;
                }
                return new Tuple<Transform, Transform>(showView, hideView.transform);
            }
                Debug.LogError("uistack has one or no element");
            return null;
        }

        private void InitUi (UIBase view) {
            if (view.UiState == UIState.NORMAL) {
                Transform transform = view.transform;
                transform.SetParent (GetLayerObject?.Invoke (view.GetUiLayer ()));
                transform.localPosition = Vector3.zero;
                transform.localScale = Vector3.one;
                transform.RectTransform ().offsetMax = Vector2.zero;
                transform.RectTransform ().offsetMin = Vector2.zero;

                InitCallBack?.Invoke (transform);
            }
        }

        public Transform GetCurrentUiTrans () {
            return _uiStack.Peek ().transform;
        }

        public Transform GetBaiscUiTrans () {
            var temArr = _uiStack.ToArray ();
            foreach (UIBase item in temArr) {
                if (item.GetUiLayer () == UILayer.BASIC_UI) {

                    return item.transform;
                }
            }
            return null;
        }

        private Transform Hide () {
            if (_uiStack.Count != 0) {
                _uiStack.Peek ().UiState = UIState.HIDE;
                return _uiStack.Pop ().transform;
            }
            return null;
        }

        public List<Transform> GetBtnParents (Transform showUI) {
            if (showUI != null) {
                return showUI.GetComponent<UIBase> ().GetBtnParents ();
            } else {
                return null;
            }
        }

        public void AddGetLayerObjectListener (Func<UILayer, Transform> fun) {
            if (fun == null) {
                Debug.LogError ("getLayout func can't be null");
                return;
            }
            GetLayerObject = fun;
        }

        public void AddInitCallBackListener (Action<Transform> callBack) {
            if (callBack == null) {
                Debug.LogError ("InitCallBack function can not be null");
                return;
            }
            InitCallBack = callBack;
        }

        private GameObject GetPrefabObject (UiId id) {
            if (!_prefabDictionary.ContainsKey (id) || _prefabDictionary[id] == null) {
                GameObject prefab = LoadManager.Instance.Load<GameObject> (Path.UI_PATH, id.ToString ());
                if (prefab) {
                    _prefabDictionary[id] = Instantiate (prefab);
                } else {
                    Debug.LogError ("can not find prefab" + id);
                }
            }
            return _prefabDictionary[id];
        }

        private UIBase GetUIScript (GameObject prefab, UiId id) {
            UIBase uiBase = prefab.GetComponent<UIBase> ();
            if (!uiBase) {
                //添加对应的UI,并返回

                return AddUiScript (prefab, id);
            }
            return uiBase;
        }

        private UIBase AddUiScript (GameObject prefab, UiId id) {
            string view = ConstValue.UI_NAMESPACE_NAME + "." + id + ConstValue.UI_SCRIPT_POSTFIX;
            Type type = Type.GetType (view);
            if (type == null) {
                Debug.LogError ("can not find view:" + view);
                return null;
            }

            return prefab.AddComponent (type) as UIBase;
        }

    }
}
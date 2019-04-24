namespace UIFrame {
    using System.Collections.Generic;
    using System.Linq;
    using System;

    using Const;

    using UnityEngine;

    public class BtnStateManager : MonoBehaviour {

        private int _parentId;
        private List<BtnParent> _currentParents = new List<BtnParent>();

        /// <summary>
        ///添加并初始化btnParent
        /// </summary>
        /// <param name="parents"></param>
        public void InitBtnParent(List<Transform> parents) {
            if (parents == null || parents.Count == 0)
            {
                return;
            }
            for (int i = 0; i < parents.Count; i++) {
                BtnParent btnParent = parents[i].gameObject.AddComponent<BtnParent>();
                btnParent.Init(i);
            }

        }

        /// <summary>
        /// 选中默认的btn
        /// </summary>
        /// <param name="parents"></param>
        public void SetDefaultBtn(List<BtnParent> parents) {
            foreach (BtnParent parent in parents) {
                parent.SelectedDefaut();
            }
        }

        /// <summary>
        /// 点击选中的btn
        /// </summary>
        public void SelectedButton() {
            _currentParents[_parentId].SelectedButton();
        }

        /// <summary>
        /// 展示某个btn
        /// </summary>
        /// <param name="showUI"></param>
        public void Show(Transform showUI) {
            ResetData();
            ResetBtnState();
            _currentParents = showUI.GetComponentsInChildren<BtnParent>(true).ToList();
            SetDefaultBtn(_currentParents);
        }

        private void ResetData() {
            _parentId = 0;
            _currentParents.Clear();
        }

        private void ResetBtnState() {
            foreach (BtnParent btnParent in _currentParents) {
                btnParent.ResetChild();
            }
        }
        public void Left() {
            MoveIndex(_currentParents[_parentId].Left, -1);
        }

        public void Right() {
            MoveIndex(_currentParents[_parentId].Right, 1);
        }

        private bool MoveIndex(Func<bool> moveAction, int symbol) {
            if (JudgeException(moveAction, symbol)) {
                return false;
            }

            if (_parentId >= 0 && _parentId < _currentParents.Count) {
                if (moveAction()) {
                    _currentParents[_parentId].SelectedState = SelectedState.SELECTED;
                    return true;
                } else {
                    _currentParents[_parentId].SelectedState = SelectedState.UNSELECTED;
                    _parentId += symbol;
                    return MoveIndex(() => { return true; }, symbol);
                }
            } else {
                ResetParentId();
                _currentParents[_parentId].SelectedState = SelectedState.SELECTED;
                return true;
            }
        }

        private bool JudgeException(Func<bool> moveAction, int symbol) {
            if (moveAction == null) {
                Debug.LogError("moveAction can't be null");
                return true;
            }
            if (symbol != 1 && symbol != -1) {
                Debug.LogError("symbol must 1 or -1");
                return true;
            }
            return false;
        }

        private void ResetParentId() {
            if (_parentId < 0) {
                _parentId = 0;
                return;
            }
            _parentId = _currentParents.Count - 1;
        }
    }

}
using System.Collections.Generic;
using System.ComponentModel;
namespace UIFrame {
    using Const;

    using UnityEngine;
    /// <summary>
    /// 绑定在名为buttons的view上，控制其中的子节点按钮
    /// </summary>
    public class BtnParent : MonoBehaviour {
        #region  --field
        public SelectedState SelectedState {
            set {
                ResetChldState();
                if (value == SelectedState.SELECTED) {
                    childs[_childId].SelectedState = SelectedState.SELECTED;
                }
            }
        }

        public int Index { get; private set; }

        public int ChildCount {
            get { return transform.childCount; }
        }

        private List<SelectedBtn> childs = new List<SelectedBtn>();
        private int _childId;
        #endregion

        public void Init(int index) {
            Index = index;
            _childId = 0;
            SelectedBtn temp;

            foreach (Transform trans in transform) {
                temp = trans.gameObject.AddComponent<SelectedBtn>();
                childs.Add(temp);
                temp.AddSelectActionListener(SelectButtonMouse);
            }
        }

        public void SelectedButton() {
            childs[_childId].SelectedButton();
        }

        public void SelectedDefaut() {
            Selected(childs[0].transform);
        }

        private void Selected(Transform btn) {
            SelectedBtn btnComponent = btn.GetComponent<SelectedBtn>();
            if (btnComponent != null) {
                btnComponent.Selected();
            }
        }

        public bool Left() {
            _childId--;
            if (_childId >= 0) {
                Selected(childs[_childId].transform);
                return true;
            } else {
                _childId = 0;
                return false;
            }

        }

        public bool Right() {
            _childId++;
            if (_childId < ChildCount) {
                Selected(childs[_childId].transform);
                return true;
            } else {
                _childId = ChildCount - 1;
                return false;
            }
        }

        private void SelectButtonMouse(SelectedBtn btn) {
            _childId = btn.Index;
            ResetChldState();
            btn.SelectedState = SelectedState.SELECTED;
        }

        private void ResetChldState() {
            foreach (SelectedBtn child in childs) {
                child.SelectedState = SelectedState.UNSELECTED;
            }
        }

        public void ResetChild()
        {
            ResetChldState();
        }
    }
}
using System;
using System.Collections.Generic;

using Const;

using Manager;

using UnityEngine;

using Util;

namespace UIFrame {
    public class StartGameView : BasicUI {
        public override List<Transform> GetBtnParents() {
            //TODO:获取transform中btnParent.
            var list = new List<Transform>();
            list.Add(transform.GetBtnParent());
            return list;
        }

        public override UiId GetUiId() {
            return UiId.StartGame;
        }

        protected override void Init() {
            base.Init();
            //init各个button事件
            transform.AddBtnListener("Continue", () => { LoadScene(true); });
            transform.AddBtnListener("Easy", () => {
                LoadScene(false);
                DataManager.Single.DifficultLevel = DifficultLevel.EASY;
            });
            transform.AddBtnListener("Normal", () => {
                LoadScene(false);
                DataManager.Single.DifficultLevel = DifficultLevel.NORMAL;
            });
            transform.AddBtnListener("Hard", () => {
                LoadScene(false);
                DataManager.Single.DifficultLevel = DifficultLevel.HARD;
            });
        }

        protected override void Show() {
            base.Show();
            SetContinueBtnState();
        }

        protected override void Hide() {

        }

        private void SetContinueBtnState() {
            bool exist = DataManager.Single.JudgeExistData();
            transform.GetBtnParent().Find("Continue").gameObject.SetActive(exist);
        }

        private void LoadScene(bool isContinue) {
            if (isContinue) {
                CotinueGame();
            } else {
                NewGame();
            }
        }

        private void NewGame() {
            var hasRecord = DataManager.Single.JudgeExistData();
            if (hasRecord) {
                RootManager.Instance.Show(UiId.NewGameWarning);
            } else {
                CotinueGame();
            }
        }

        private void CotinueGame() {
            RootManager.Instance.Show(UiId.Loading);
        }

    }
}
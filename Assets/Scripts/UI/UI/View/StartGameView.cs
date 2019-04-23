using System;
using System.Collections.Generic;
using Const;
using Manager;
using UnityEngine;
using Util;

namespace UIFrame {
    public class StartGameView : BasicUI {
        public override List<Transform> GetBtnParents () {
            //TODO:获取transform中btnParent.
            var list = new List<Transform> ();
            list.Add (transform.GetBtnParent ());
            return list;
        }

        public override UiId GetUiId () {
            return UiId.StartGame;
        }

        protected override void Init () {
            base.Init ();
            //init各个button事件
            transform.AddBtnListener ("Continue", () => { LoadScene (true); });
            transform.AddBtnListener ("Easy", () => {

            });
            transform.AddBtnListener ("Normal", () => {

            });
            transform.AddBtnListener ("Hard", () => {

            });
        }

        protected override void Show () {

        }

        protected override void Hide () {

        }

        private void LoadScene (bool isContinue) {

        }

        private void NewGame () {
            var hasRecord = DataManager.Single.JudgeExistData ();
            if (hasRecord) {
                RootManager.Instance.Show (UiId.NewGameWarning);
            } else {
                CotinueGame ();
            }
        }

        private void CotinueGame () {
            RootManager.Instance.Show (UiId.Loading);
        }

    }
}
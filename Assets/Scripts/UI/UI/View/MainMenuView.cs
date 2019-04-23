using System.Collections.Generic;
using Const;
using UnityEngine;
using Util;
using DG.Tweening;

namespace UIFrame {
    public class MainMenuView : BasicUI {
        public override List<Transform> GetBtnParents () {
            List<Transform> list = new List<Transform> ();

            var btnParent = transform.GetBtnParent ();
            list.Add (transform.GetBtnParent ());

            return list;
        }

        public override UILayer GetUiLayer () {
            return UILayer.BASIC_UI;
        }

        public override UiId GetUiId () {
            return UiId.MainMenu;
        }

        protected override void Init() {
            base.Init();
            transform.AddBtnListener ("StartGame", () => { });
            transform.AddBtnListener ("DOJO", () => { });
            transform.AddBtnListener ("Help", () => { });
            transform.AddBtnListener ("ExitGame", () => { Application.Quit (); });
            Invoke("ShowButtons", 0.25f);
            
        }

        private void ShowButtons(){
           Transform ui = transform.Find("Buttons");
       
            ui.DOLocalMoveY( -325f, 0.25f, false);
     
        }
    }
}
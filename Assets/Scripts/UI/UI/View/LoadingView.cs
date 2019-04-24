using System.Collections.Generic;
using System.Threading;

using Const;

using Manager;

using UnityEngine;

using Util;

namespace UIFrame {
    public class LoadingView : OverlayUI {

        public override UiId GetUiId() {
            return UiId.Loading;
        }

        public override List<Transform> GetBtnParents() {
            var list = new List<Transform>();
            var btnParent = transform.GetBtnParent();
            if (btnParent == null) {
                return null;
            }
            list.Add(btnParent);
            return list;
        }

        protected override void Show() {
            base.Show();

            Debug.Log(" Thread.CurrentThread Show:" + Thread.CurrentThread.IsBackground);

            //使用协程，在后台加载场景(但还是在相同的场景)；正常逻辑代码是当_operation.progress = 1 的时候显示对应的场景，这里写了个伪代码
            StartCoroutine(LoadSceneManager.Single.LoadSceneAsync(DataManager.Single.GetSceneName()));
            LoadSceneManager.Single.AllowSwitchScene();
            transform.SetAsLastSibling();

        }
    }
}
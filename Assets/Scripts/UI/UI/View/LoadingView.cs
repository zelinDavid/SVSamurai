using System.Collections.Generic;
using Const;
using Manager;
using UnityEngine;
using Util;

namespace UIFrame
{
    public class LoadingView : OverlayUI     
    {
       
        public override UiId GetUiId()
        {
            return UiId.Loading;
        }

        public override List<Transform> GetBtnParents()
        {
             var list = new List<Transform>();
             var btnParent = transform.GetBtnParent();
             if (btnParent == null)
             {
                 return null;
             }
             list.Add(btnParent);
             return list;
        }

        protected override void Show()
        {
            base.Show();
            StartCoroutine(LoadSceneManager.Single.LoadSceneAsync(DataManager.Single.GetSceneName()));
            LoadSceneManager.Single.AllowSwitchScene();
            transform.SetAsLastSibling();
 
        }
    }
}

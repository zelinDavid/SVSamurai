using System;
using System.Collections.Generic;
using Const;
using UnityEngine;
using UnityEngine.UI;

namespace Util
{
    public static class ExtendUtil
    {
        
        public static RectTransform RectTransform(this Transform transform){
           var rect = transform.GetComponent<RectTransform>();
            if (rect)
            {
                return rect;
            }
            Debug.LogError("can not find RectTransfomr");
            return null;
        }

        public static Transform GetBtnParent(this Transform transform){
           var parent = transform.Find(ConstValue.BUTTON_PARENT_NAME);
           if (parent)
           {
               return parent;
           }
           Debug.LogError("GetBtnParent not find");
           return null;
        }

        public static void AddBtnListener(this Transform transform, string btnName, Action callback){
          var button = transform.Find(ConstValue.BUTTON_PARENT_NAME + "/" +btnName);
          if (button)
          {
              button.AddBtnListener(callback);
          }
        }

        public static void AddBtnListener(this Transform transform, Action callBack){
            var btnComponent = transform.GetComponent<Button>()?? transform.gameObject.AddComponent<Button>();
            btnComponent.onClick.AddListener(() => callBack());
        }

        public static void AddBtnListener(this RectTransform rect, Action action) //重载
        {
            var button = rect.GetComponent<Button>() ?? rect.gameObject.AddComponent<Button>();

            button.onClick.AddListener(()=> action());
        }
 

    }
}
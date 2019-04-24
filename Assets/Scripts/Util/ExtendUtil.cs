using System;
using System.Collections.Generic;

using Const;

using UnityEngine;
using UnityEngine.UI;

namespace Util {
    public static class ExtendUtil {

        public static RectTransform RectTransform(this Transform transform) {
            var rect = transform.GetComponent<RectTransform>();
            if (rect) {
                return rect;
            }
            Debug.LogError("can not find RectTransfomr");
            return null;
        }

        public static Transform GetBtnParent(this Transform transform) {
            var parent = transform.Find(ConstValue.BUTTON_PARENT_NAME);
            if (parent) {
                return parent;
            }
            Debug.LogError("GetBtnParent not find");
            return null;
        }

        public static void AddBtnListener(this Transform transform, string btnName, Action callback) {
            var button = transform.Find(ConstValue.BUTTON_PARENT_NAME + "/" + btnName);
            if (button) {
                button.AddBtnListener(callback);
            }
        }

        public static void AddBtnListener(this Transform transform, Action callBack) {
            var btnComponent = transform.GetComponent<Button>() ?? transform.gameObject.AddComponent<Button>();
            btnComponent.onClick.AddListener(() => callBack());
        }

        public static void AddBtnListener(this RectTransform rect, Action action) //重载
        {
            var button = rect.GetComponent<Button>() ?? rect.gameObject.AddComponent<Button>();

            button.onClick.AddListener(() => action());
        }

        public static T getOrAddComponent<T>(this Transform transform) where T : Component {
            T temBehavior = transform.GetComponent<T>();
            if (temBehavior != null) {
                return temBehavior;
            } else {
                temBehavior = transform.gameObject.AddComponent<T>();
                return temBehavior;
            }
        }

        public static Image Image(this Transform transform) {
            var image = transform.GetComponent<Image>();

            if (image != null) {
                return image;
            } else {
                Debug.LogError("can not find Image");
                return null;
            }
        }

        public static Button Button(this Transform transform) {
            var button = transform.GetComponent<Button>();

            if (button != null) {
                return button;
            } else {
                Debug.LogError("can not find Image");
                return null;
            }
        }

        public static Transform GetByName(this Transform transform, string name) {
            Transform obj = transform.Find(name);
            if (obj == null) {
                Debug.LogError("getbyName can't get by name:" + name);
                return null;
            }
            return obj;
        }
    }
}
using System;
using System.Collections.Generic;
using Const;
using UnityEngine;

namespace UIFrame {
    public class UILayerManager : MonoBehaviour {
        private Dictionary<UILayer, Transform> _layerDictionary = new Dictionary<UILayer, Transform> ();

        private void Awake () {
            var temList = Enum.GetValues (typeof (UILayer));

            foreach (UILayer item in temList) {
                Transform transform = gameObject.transform.Find (item.ToString ());
                if (transform != null) {
                    _layerDictionary.Add (item, transform);
                }
            }
        }

        public Transform GetLayerObject(UILayer layer){
            if (_layerDictionary.ContainsKey(layer))
            {
                return _layerDictionary[layer];
            }

            Debug.LogError("GetLayerObject no object:" + layer);
            return null;
        }

    }
}
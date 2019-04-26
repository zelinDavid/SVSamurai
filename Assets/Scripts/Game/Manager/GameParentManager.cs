using System.Collections.Generic;

using UnityEngine;

using Util;

namespace Game {
    /// <summary>
    /// 场景内父物体管理器
    /// </summary>
    /// enum ParentName: playerRoot, cameraController, UIController
    /// dictionary: name, transform
    /// init(): init dictionary
    /// public getParentTrans (enum / string)
    public class GameParentManager : MonoBehaviour {
        Dictionary<string, Transform> _parentName;

        public void Init() {
            _parentName = new Dictionary<string, Transform>();
            foreach (Transform item in transform) {
                _parentName.Add(item.name, item);
            }
        }

        public Transform GetParentTrans(string parentName) {
            Transform parent;
            _parentName.TryGetValue(parentName, out parent);
            _parentName.UtilDebugLogNull();

            return parent;
        }

        public Transform GetParentTrans(ParentName parentName) {
            Transform parent;
            _parentName.TryGetValue(parentName.ToString(), out parent);
            _parentName.UtilDebugLogNull();
            
            return parent;
        }
    }

    public enum ParentName {
        PlayerRoot,
        UIController,
        CameraController,
    }
}
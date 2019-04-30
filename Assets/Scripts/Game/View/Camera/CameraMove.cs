using System;
using System.Numerics;
namespace Game {
    using DG.Tweening;

    using UnityEngine;

    //初始化相机位置为0； 移动摄像头，使rotation为0；并且设置callback;
    public class CameraMove : MonoBehaviour {

        public void Init(Transform parent) {
            SetParent(parent);
            transform.localPosition = Vector3.zero;
            transform.localEulerAngles = Vector3.zero;
        }

        public void Move(Transform parent, Action callBack) {
            SetParent(parent);
            float time = 2  * 0.01f;

            transform.DOKill();
            transform.DOLocalMove(Vector3.zero, time);
            transform.DOLocalRotate(Vector3.zero, time).OnComplete(()=> callBack?.Invoke());
        }

        public void SetParent(Transform parent) {
            transform.SetParent(parent);
        }

    }
}
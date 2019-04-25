using System;
using System.Collections.Generic;
using Entitas;
using DG.Tweening;

using Manager;

using UnityEngine;

using Util;

namespace Game {
    /*
     先看camera相关逻辑， 再编写
     增加camera相关component; 一边写一边增加对应的类

        initCameraParent; 
            创建CameraParent Enum; 遍历Enum获取到父物体 加入字典中；
        initGameCamera;
        为in_game下的camera添加cameraMove组件：
            初始化相机位置为0； 移动摄像头，使rotation为0；并且设置callback;
        为Fllow_player对象添加FollowPlayer组件；
            start初始化各种数据.
            update使用do动画移动物体；
                判断是否在移动， 旋转，移动
        controller添加监听状态改版事件
     */

    public class CameraCtroller : ViewBase, IGameCameraStateListener {
        private CameraMove _cameraMove;
        private Camera _camera;
        private Dictionary<CameraParent, Transform> _parentDic = new Dictionary<CameraParent, Transform>();

        
        public override void Init(Contexts contexts, Entitas.IEntity entity) {
            base.Init(contexts, entity);

            InitParent();
            InitGameCamera();
            InitFollowPlayer();
        }

        private void InitParent() {
            Transform temParent;
            foreach (CameraParent parent in Enum.GetValues(typeof(CameraParent))) {
                temParent = transform.GetByName(parent.ToString());
                if (temParent != null) {
                    _parentDic.Add(parent, temParent);
                }
            }
        }

        private void InitGameCamera() {
            _camera = transform.UtilGetComponentInChildren<Camera>();
            if (_camera == null) {
                return;
            }
            _cameraMove = _camera.transform.getOrAddComponent<CameraMove>();
            if (_cameraMove == null) {
                return;
            }

            Transform parent = null;

            if (DataManager.Single.LevelGamePartIndex == LevelGamePartID.ONE) {
                parent = GetCameraParent(CameraParent.START);
            } else {
                parent = GetCameraParent(CameraParent.IN_GAME);
            }
            if (parent != null) {
                _cameraMove.Init(parent);
            }
        }

        private Transform GetCameraParent(CameraParent cameraParent) {
            if (_parentDic.TryGetValue(cameraParent, out Transform camera)) {
                return camera;
            }
            Debug.LogError("Get GetCameraParent fail:" + cameraParent.ToString());
            return null;
        }

        /*为Fllow_player对象添加FollowPlayer组件；
                start初始化各种数据.
                update使用do动画移动物体；
                    判断是否在移动， 旋转，移动 */
        private void InitFollowPlayer() {
            _parentDic[CameraParent.FOLLOW_PLAYER].getOrAddComponent<FollowPlayer>();

        }

        public void OnGameCameraState(GameEntity entity, CameraAniName state) {
            Transform parnet = null;
            switch (state) {
                case CameraAniName.FOLLOW_PLAYER:
                    parnet = GetCameraParent(CameraParent.IN_GAME);
                    if (parnet != null) _cameraMove.Move(parnet, StartAniCallBack);
                    break;
                case CameraAniName.START_GAME_ANI:
                    parnet = GetCameraParent(CameraParent.FOLLOW_PLAYER);
                    if (parnet != null) _cameraMove.Move(parnet, null);
                    break;
                case CameraAniName.SHAKE_ANI:
                    Shake();
                    break;
            }
        }

        private void StartAniCallBack(){
            Contexts.sharedInstance.game.ReplaceGameCameraState(CameraAniName.FOLLOW_PLAYER);
        }

        private void Shake() {
            if (_camera != null) {
                _camera.DOShakePosition(0.2f, 0.5f, 20);
            }
        }

    }

}
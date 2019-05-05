using Entitas;

using Game.Service;

using Manager;

using UnityEngine;

using Util;

namespace Game {
    public class GameController : MonoBehaviour {
        Systems _systems;
        Contexts _contexts;
        IServiceManager _serviceManager;

        private void Awake() {
            _contexts = Contexts.sharedInstance;

            InitManager();

            _systems = new InitFeature(_contexts);
            _systems.Initialize();

            _contexts.game.SetGameGameState(GameState.START);

        }

        void InitManager() {
            ModelManager.Single.Init();

            GameParentManager parentManager = transform.getOrAddComponent<GameParentManager>();
            parentManager.Init();

            var cameraTransform = parentManager.GetParentTrans(ParentName.CameraController);
            // Debug.Log("CameraController:" + cameraTransform);
            CameraCtroller cameraCtroller = cameraTransform.getOrAddComponent<CameraCtroller>();
            GameEntity entity = _contexts.game.SetGameCameraState(CameraAniName.NULL);
            cameraCtroller.Init(_contexts, entity);

            _serviceManager = new ServiceManager(parentManager);
            _serviceManager.Init(_contexts);

            

            var uiControllerView = parentManager.GetParentTrans(ParentName.UIController);
            if (!uiControllerView.UtilDebugLogNull()) {
                UIController uiController = uiControllerView.getOrAddComponent<UIController>();
                uiController.Init();
            }
            
            LoadAudioManager.Single.Init();

        }

        private void Update() {
            _serviceManager.Execute();
            _systems.Execute();
            _systems.Cleanup();
        }

        private void OnDestroy() {
            _systems.TearDown();
        }

    }
}
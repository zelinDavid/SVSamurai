using Manager;

using UnityEngine;

namespace Game.Service {
    /*
        ILoadService：
            /// <summary>
            /// 加载玩家预制
            /// </summary>
            void LoadPlayer();
            void LoadEnemy(string enemyName, Transform parent);

        LoadService： loadManager功能 + 预制player/enemey/wall 
    
        LoadPlayer
            IgnorForce PlayerCollider PlayerView ... 

     */

    public interface ILoadService : ILoad, IInitService {
        void LoadPlayer();
        void LoadEnemy(string enemeyName, Transform parent);
    }

    public class LoadService : ILoadService {
        GameParentManager _parentManager;

        public LoadService(GameParentManager parentManager) {
            _parentManager = parentManager;
        }

        public void Init(Contexts contexts) {
            contexts.service.SetGameServiceLoadService(this);
        }

        public int GetPriority() {
            return 0;
        }

        public T Load<T>(string path, string name) where T : class {
            return LoadManager.Single.Load<T>(path, name);
        }

        public T[] LoadAll<T>(string path) where T : Object {
            return LoadManager.Single.LoadAll<T>(path);
        }

        public GameObject LoadAndInstaniate(string path, Transform parent) {
            return LoadManager.Single.LoadAndInstaniate(path, parent);

        }

        public void LoadEnemy(string enemeyName, Transform parent) {
            throw new System.NotImplementedException();
        }

        /*
        实例化player;添加 IgnorForce PlayerCollider 组件；
        添加 playerView
        实例化 IPlayerBehavior 及 IPlayerAni; IPlayerAudio

        天啊及状态机 及  PlayerAni CustomAniEventManager
        添加以上信息到gamePlayerComponent；
        IView初始化
        
        LoadTrail
        */

        public void LoadPlayer() {
            var player = LoadAndInstaniate(Path.PLAYER_PREFAB , _parentManager.GetParentTrans(ParentName.PlayerRoot));


            
        }
    }
}
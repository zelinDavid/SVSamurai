using System;

using Const;

using Manager;

using UnityEngine;

using Util;

namespace Game {

    // prefix  nameSpace;  loadView
    public class UIController : MonoBehaviour {
        string _nameSpace = "Game.View";
        string _postfix = "View";

        public void Init() {
            LoadView();
        }

        void LoadView() {
            GameObject go;
            Component temComponent;
            foreach (var view in Enum.GetValues(typeof(GameUIName))) {
                go = LoadManager.Single.LoadAndInstaniate(Path.GAME_UI_PATH + view, transform);
                if (!go.UtilDebugLogNull()) {
                    temComponent = go.AddComponent(Type.GetType(_nameSpace + view + _postfix));
                    if (temComponent is IView) {
                        (temComponent as IView).Init(Contexts.sharedInstance, Contexts.sharedInstance.game.CreateEntity());
                    }
                }
            }
        }
    }
}
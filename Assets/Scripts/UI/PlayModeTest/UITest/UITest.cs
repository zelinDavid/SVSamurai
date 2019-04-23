using System.Collections;
using System.Collections.Generic;
using Const;
using Manager;
using NUnit.Framework;
using UIFrame;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.UI;

namespace Tests {
    public class UITest {

        // A Test behaves as an ordinary method
        // [Test]
        // public void UITestSimplePasses()
        // {
        //     // Use the Assert class to test conditions
        // }

        // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
        // `yield return null;` to skip a frame.
        [UnityTest]
        public IEnumerator UITestWithEnumeratorPasses () {
            GameObject canvas = LoadManager.Single.LoadAndInstaniate (Path.PREFAB_PATH + ConstValue.CANVAS, null);
            GameObject base_layer = GameObject.Find ("BASIC_UI");
            UIManager uiManager = canvas.AddComponent<UIManager> ();
            UILayerManager _layerManager = canvas.AddComponent<UILayerManager> ();
            uiManager.AddGetLayerObjectListener (_layerManager.GetLayerObject);
            uiManager.Show (UiId.MainMenu);
            yield return new WaitForSeconds (5);
            // uiManager.Show (UiId.StartGame);
            // yield return new WaitForSeconds (5);
            // uiManager.Show (UiId.NewGameWarning);
            // yield return new WaitForSeconds (5);
            // uiManager.Back();
            // yield return new WaitForSeconds (5);
            
            Debug.Log ("finishShow");
            GameObject.Destroy (canvas);
        }
    }
}
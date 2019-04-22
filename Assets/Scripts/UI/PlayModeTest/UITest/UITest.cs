using System.Collections;
using System.Collections.Generic;
using Const;
using NUnit.Framework;
using UIFrame;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.UI;

namespace Tests
{
    public class UITest:IPrebuildSetup
    {
        public GameObject obj;
        public void Setup()
        {
             obj = new GameObject("dddd");
        }



        // A Test behaves as an ordinary method
        // [Test]
        // public void UITestSimplePasses()
        // {
        //     // Use the Assert class to test conditions
        // }

        // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
        // `yield return null;` to skip a frame.
        [UnityTest]
        public IEnumerator UITestWithEnumeratorPasses()
        {   
            while (true)
            {   yield return new WaitForSeconds(1);
                var test = GameObject.Find("dddd");
                Debug.Log(test);
            }
            
            // GameObject _canvas = new GameObject("Canvas", typeof(Canvas),typeof(CanvasScaler),typeof(GraphicRaycaster));
            
            // UIManager  man =  _canvas.AddComponent<UIManager>();
            // man.Show(UiId.MainMenu);
            // Debug.Log("showManiViwe");
            // yield return new WaitForSeconds(20);
            // Debug.Log("finishShow");

            
        }
    }
}

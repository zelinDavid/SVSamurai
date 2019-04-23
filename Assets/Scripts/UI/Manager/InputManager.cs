using Const;
using UnityEngine;

namespace UIFrame
{
    public class InputManager : MonoBehaviour     
    {
         private void Update() {
             
             if (Input.GetKeyDown(KeyCode.Escape))
             {
                RootManager.Instance.Back();    
             }

            if (Input.GetMouseButtonDown(0))
            {
                RootManager.Instance.PlayAudio(UIAudioName.UI_click);
            }

            BtnSelected();

         }

         private void BtnSelected(){
             //TODO:上次写到这儿
             
         }
    }
}

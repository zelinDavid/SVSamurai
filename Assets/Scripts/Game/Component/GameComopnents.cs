using System.Security.Cryptography.X509Certificates;
using Entitas;
using Entitas.CodeGeneration.Attributes;
using UnityEngine;

namespace Game
{
    /// <summary>
    /// 摄像机状态组件
    /// </summary>
    [Game,Event(EventTarget.Self),Unique]
    public class CameraState: IComponent
    {
        public CameraAniName state; 
    } 

    [Game,Unique]
    public class PlayerComponent:IComponent
    {
        public IView Player;
        public IPlayerBehaviour Behavior;
        public IPlayerAni Ani;
        public IPlayerAudio Audio;
    }


}

using Entitas;
using Entitas.CodeGeneration.Attributes;
using UnityEngine;

namespace Game
{
    
    [Game,Event(EventTarget.Self),Unique]
    public class CameraState: IComponent
    {
        public CameraAniName state; 
    } 

}


using Entitas;
using Entitas.CodeGeneration.Attributes;
using UnityEngine;

namespace Game
{
    /// <summary>
    /// 输入按钮
    /// </summary>
    [Input,Unique]
     public class InputButtonComponent: IComponent
     {
        public InputButton InputButton;
        public InputState InputState;

     }

    /// <summary>
    /// 人物技能
    /// </summary>
    [Input, Unique]
     public class InputHumanSkillState: IComponent
     {
        /// <summary>
        /// 标记连续技能输入是否结束
        /// </summary>
        public bool IsEnd;
        /// <summary>
        /// 技能编码
        /// </summary>
        public int SkillCode;  
     }
}

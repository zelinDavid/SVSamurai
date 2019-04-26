using Entitas;
using Entitas.CodeGeneration.Attributes;

using UnityEngine;

namespace Game.Service {
    /// <summary>
    /// 查找服务组件
    /// </summary>
    [Service, Unique]
    public class FindObjectServiceComponent : IComponent {
        public IFindObjecService findObjectService;
    }

}
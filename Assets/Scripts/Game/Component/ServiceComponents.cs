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

    /// <summary>
    /// 输入服务组件
    /// </summary>
    [Service, Unique]
    public class EntitasInputServiceComponent : IComponent {
        public IInputService EntitasInputService;
    }

    /// <summary>
    /// 输入服务组件
    /// </summary>
    [Service, Unique]
    public class LogServiceComponent : IComponent {
        public ILogService LogService;
    }

    /// <summary>
    /// 输入服务组件
    /// </summary>
    [Service, Unique]
    public class LoadServiceComponent : IComponent {
        public ILoadService LoadService;
    }

}
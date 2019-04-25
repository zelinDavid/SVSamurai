using Entitas;
using Entitas.Unity;
using UnityEngine;

namespace Game
{
    public class ViewBase : MonoBehaviour, IView
    {
        protected GameEntity _entity;
        public virtual void Init(Contexts contexts, IEntity entity)
        {
            gameObject.Link(entity);
            if (entity is GameEntity)
            {
               _entity = entity as GameEntity;
            }
        }
    }
}

using Entitas;
using Entitas.Unity;
using UnityEngine;

namespace Game
{
    public class ViewBase : MonoBehaviour, IView
    {
        protected GameEntity _entity;
        protected Contexts _contexts;
        public virtual void Init(Contexts contexts, IEntity entity)
        {
            _contexts = contexts;
            gameObject.Link(entity);
            if (entity is GameEntity)
            {
               _entity = entity as GameEntity;
            }
        }

    }
}

namespace Game
{
    /// <summary>
    /// 基础view,与entity绑定，方便之后扩展
    /// </summary>
    public class PlayerView:ViewBase
    {
        public override void Init(Contexts contexts, Entitas.IEntity entity){
            base.Init(contexts, entity);
        }
    }
}
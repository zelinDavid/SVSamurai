using Entitas;

namespace Game
{
    public class GameInitGameSystem : IInitializeSystem
    {
        protected Contexts _contexts;

        public GameInitGameSystem(Contexts contexts)
        {
            _contexts = contexts;
        }

        public void Initialize()
        {
            _contexts.service.gameServiceLoadService.LoadService.LoadPlayer();
        }
    }
}
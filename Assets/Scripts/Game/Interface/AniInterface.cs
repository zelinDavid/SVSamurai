

namespace Game
{
    
    public interface IAni {
    void Play(int aniIndex);
    
    }

    public interface IPlayerAni:IAni,IPlayerBehaviour {
        
    }
}
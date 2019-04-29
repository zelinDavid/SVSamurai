namespace Game {

    public interface IAni {
        void Play(int aniIndex);
        ICustomAniEventManager AniEventManager { get; set; }
    }

    public interface IPlayerAni : IAni, IPlayerBehaviour {

    }
}
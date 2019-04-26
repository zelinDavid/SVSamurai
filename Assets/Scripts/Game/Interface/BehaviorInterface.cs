namespace Game
{
    /// <summary>
    /// 基础行为接口
    /// </summary>
    public interface IBehaviour {
        void Idle();
        void TurnForward();
        void TurnBack();
        void TurnLeft();
        void TrunRight();
        void Move();
    }
    
    public interface IPlayerBehaviour :IBehaviour {
        bool IsRun{ set;get;}
        bool IsCollideWall{set; get;}
        bool IsAttack{get;}
        void Attack(int skillCode);
        
    }
}
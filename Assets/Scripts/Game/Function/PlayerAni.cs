using Const;
using UnityEngine;

namespace Game {
    /*
        构造函数： Animator, ICustomAniEventManager

        Player(int aniIndex)

        attack(int skillCode)
    

     */

    public class PlayerAni : IPlayerAni {
        public ICustomAniEventManager AniEventManager { get; set; }
        public bool IsRun { get; set; }
        public bool IsCollideWall { get; set; }

        public bool IsAttack { get; }
        Animator _animator;
        public PlayerAni(Animator animator, ICustomAniEventManager customEventManager) {
            AniEventManager = customEventManager;
            _animator = animator;
        }

        public void Attack(int skillCode) {
            _animator.SetInteger(ConstValue.PLAYER_PARA_NAME, skillCode);
            _animator.SetBool(ConstValue.IDLE_SWORD_PARA_NAME, true);
        }

        public void Idle() {
            Play(PlayerAniIndex.IDLE);
        }

        public void Move() {
            if (IsRun) {
                Play((int) PlayerAniIndex.RUN);
            } else {
                Play((int) PlayerAniIndex.WALK);
            }
        }

        public void Play(PlayerAniIndex aniIndex) {
            
            Play((int)aniIndex);
        }

        public void Play(int aniIndex) {
            _animator.SetInteger(ConstValue.PLAYER_PARA_NAME, aniIndex);
        }

        public void TurnBack() {
            
        }

        public void TurnForward() {
            
        }

        public void TurnLeft() {
          
        }

        public void TurnRight() {
            
        }
    }

}
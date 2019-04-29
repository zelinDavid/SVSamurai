using System;
using System.Linq;
using System.Threading.Tasks;

using Const;

using UnityEditor;

using UnityEngine;

namespace Game {

    public class PlayerAudio : IPlayerAudio {

        private AudioSource _audioSource;
        private int _times;
        private bool _isRun;

        public bool IsRun {
            get => _isRun;
            set {
                _isRun = value;
                _times = 0;
            }
        }
 
        public bool IsCollideWall { get; set; }

        public bool IsAttack { get; }

        public PlayerAudio(AudioSource source) {
            _audioSource = source;
            _times = 0;

        }

        public async void Attack(int skillCode) {
            await Task.Delay(TimeSpan.FromSeconds((double) ConstValue.SKILL_START_TIME));
            Play(AudioName.attack);
        }

        private int GetFrames(){
            if (IsRun)
            {
                return ConstValue.RUN_STEP_TIME;
            }else {
                return ConstValue.WALK_STEP_TIME;

            }
        }

        public void Idle() {
             
        }

        public void Move() {
            if (_times == 0)
            {
                Play(AudioName.step, ConstValue.MOVE_STEP_VOLUME);
            }
            _times ++;
            if (_times >= GetFrames())
            {
                _times = 0;
            }
        }

        public void TurnRight() {
            
        }

        public void TurnBack() {
            
        }

        public void TurnForward() {
             
        }

        public void TurnLeft() {
            
        }

        public void Play(AudioName name, float volume = 1) {
            Play(name.ToString(),volume );
        }

        public void Play(string name, float volume = 1 ) {

             _audioSource.PlayOneShot(GetAudioClip(name),volume);
        }

         private AudioClip GetAudioClip(string name)
        {
            return LoadAudioManager.Single.PlayerAudio(name);
        }

    }
}
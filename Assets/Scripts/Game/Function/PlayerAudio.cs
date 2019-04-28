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

        public PlayerAudio(bool isCollideWall, bool isAttack) {
            this.IsCollideWall = isCollideWall;
            this.IsAttack = isAttack;

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

        public void Idle() {
            throw new System.NotImplementedException();
        }

        public void Move() {
            throw new System.NotImplementedException();
        }

        public void TrunRight() {
            throw new System.NotImplementedException();
        }

        public void TurnBack() {
            throw new System.NotImplementedException();
        }

        public void TurnForward() {
            throw new System.NotImplementedException();
        }

        public void TurnLeft() {
            throw new System.NotImplementedException();
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
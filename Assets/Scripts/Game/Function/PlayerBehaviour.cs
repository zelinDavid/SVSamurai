using System;

using DG.Tweening;

using Model;

using UnityEngine;

namespace Game {

    public class PlayerBehaviour : IPlayerBehaviour {
        public bool IsRun { get; set; }

        public bool IsCollideWall { get; set; }

        public bool IsAttack { get; set; }

        private readonly Transform _playerTrans;
        private readonly PlayerDataModel _model;
        private Vector3 _faceDirection;
        private bool _isFaceDirectionChange;

        public PlayerBehaviour(Transform player, PlayerDataModel model) {
            _playerTrans = player;
            _model = model;
            IsAttack = false;
            _faceDirection = Vector3.zero;
            _isFaceDirectionChange = false;
        }

        private void SetDirectionData(Vector3 direction) {
            if (_faceDirection != direction) {
                _faceDirection = direction;
                _isFaceDirectionChange = true;
            }
        }

        public void Attack(int skillCode) {
            throw new System.NotImplementedException();
        }

        public void Idle() {
            IsAttack = false;
        }

        public void Move() {
            if (_isFaceDirectionChange) {
                IsCollideWall = false;
            }
            PlayerMove();
        }

        private void PlayerMove() {
            if (IsCollideWall) {
                return;
            }
            _playerTrans.Translate(Time.deltaTime * _model.Speed * Vector3.forward, Space.Self);
        }

        private void RotateFace() {
            if (_isFaceDirectionChange) {
                _isFaceDirectionChange = false;
                PlayerOrientation(_faceDirection);
            }
        }

        private void PlayerOrientation(Vector3 direction) {
            var degree = Math.Abs((_playerTrans.eulerAngles - direction).y);
            if (degree == 90) {
                _playerTrans.DORotate(direction, 0.3f);
            } else {
                _playerTrans.eulerAngles = direction;
            }
        }

        public void TrunRight() {
            if (IsAttack)
                return;
            SetDirectionData(Vector3.up * 90);
        }

        public void TurnBack() {
            if (IsAttack)
                return;
            SetDirectionData(Vector3.up * 180);
        }

        public void TurnForward() {
            if (IsAttack)
                return;
            SetDirectionData(Vector3.zero);
        }

        public void TurnLeft() {
            if (IsAttack)
                return;
            SetDirectionData(Vector3.up * -90);
        }
    }
}
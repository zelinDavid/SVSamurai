using Const;

using DG.Tweening;

using UnityEngine;

namespace Game {
    /*为Fllow_player对象添加FollowPlayer组件；
            start初始化各种数据.
            update使用do动画移动物体；
                判断是否在移动， 旋转，移动 */
    public class FollowPlayer : MonoBehaviour {
        Transform _player;
        bool _isMoving;
        float _rotateValue;
        float _rotateDuration;
        Vector3 _lastPos;
        Vector3 _defaultEul;
        Vector3 _offSet;

        private void Start() {
            _player = GameObject.FindGameObjectWithTag(TagAndLayer.TAG_PLAYER).transform;
            _defaultEul = transform.eulerAngles;
            _rotateValue = 1f;
            _isMoving = false;
            _rotateDuration = 0.8f;
            _lastPos = transform.position;
            Transform playerRoot = _player.parent;
            _offSet = transform.position - playerRoot.position;
        }

        private void Update() {
            if (Vector3.Distance(_lastPos, _player.position) < 0.01f && _isMoving) {
                _isMoving = false;
                transform.DORotate(_defaultEul, _rotateDuration);
            } else if (Vector3.Distance(_lastPos, _player.position) > 0.01f && !_isMoving) {
                _isMoving = true;
                int x = GetXDirection();
                int z = GetZDirection();
                transform.DORotate(_defaultEul + new Vector3(_rotateValue * z, 0, _rotateValue * x), _rotateDuration);

            } else {
                transform.DOMove(_player.position + _offSet, 0.4f);
            }
            _lastPos = transform.position;
        }

        private int GetXDirection() {
            if (transform.position.x == _lastPos.x) {
                return 0;
            }
            return transform.position.x > _lastPos.x ? 1 : -1;
        }

        private int GetZDirection() {
            if (transform.position.z == _lastPos.z) {
                return 0;
            }
            return transform.position.z > _lastPos.z ? 1 : -1;
        }
    }
}
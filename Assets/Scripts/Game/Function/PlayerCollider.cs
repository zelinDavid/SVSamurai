using Const;

using UnityEngine;

namespace Game {
    public class PlayerCollider : MonoBehaviour {
        private void OnTriggerEnter(Collider other) {
            if (other.tag == TagAndLayer.TAG_WALL) {
                Contexts.sharedInstance.game.gamePlayer.Ani.IsCollideWall = true;
            }
        }

        private void OnTriggerStay(Collider other) {
            if (other.tag == TagAndLayer.TAG_WALL) {
                if (Physics.Raycast(transform.position, transform.forward, out RaycastHit hit, 0.5f)) {
                    Contexts.sharedInstance.game.gamePlayer.Ani.IsCollideWall = hit.collider.tag == TagAndLayer.TAG_WALL;
                } else {
                    Contexts.sharedInstance.game.gamePlayer.Ani.IsCollideWall = false;
                }
            }
        }
    }
}
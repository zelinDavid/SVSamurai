namespace Game
{
    using UnityEngine;
    
    public class IgnorForce : MonoBehaviour {
        private Rigidbody _rigidbody;
        
        private void Start() {
            _rigidbody = GetComponent<Rigidbody>();
        }

        private void Update()
        {
            _rigidbody.velocity = Vector3.zero;
        }
    }
}
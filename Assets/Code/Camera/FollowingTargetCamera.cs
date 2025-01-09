using UnityEngine;

namespace Dimasyechka
{
    public class FollowingTargetCamera : MonoBehaviour
    {
        [SerializeField]
        private Transform _cameraTransform;

        [SerializeField]
        private Transform _targetTransform;


        [SerializeField]
        private Vector3 _offset;


        [SerializeField]
        private bool _followX = true;
        public bool FollowX { get => _followX; set => _followX = value; }

        [SerializeField]
        private bool _followY = true;
        public bool FollowY { get => _followY; set => _followY = value; }


        private void LateUpdate()
        {
            FollowTarget();
        }


        private void FollowTarget()
        {
            if (_targetTransform == null || _cameraTransform == null) return;

            Vector3 desiredPosition = _targetTransform.position + _offset;

            if (_followX)
            {
                if (_targetTransform.position.x >= _cameraTransform.position.x - _offset.x)
                {
                    desiredPosition.x = _targetTransform.position.x + _offset.x;
                }
                else
                {
                    desiredPosition.x = _cameraTransform.position.x;
                }
            }
            else
            {
                desiredPosition.x = _cameraTransform.position.x;
            }


            if (_followY)
            {
                desiredPosition.y = _targetTransform.position.y + _offset.y;
            }
            else
            {
                desiredPosition.y = _cameraTransform.position.y;
            }


            _cameraTransform.position = desiredPosition;
        }
    }
}

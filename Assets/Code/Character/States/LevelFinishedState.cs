using UnityEngine;

namespace Dimasyechka
{
    public class LevelFinishedState : PlayerState
    {
        public LevelFinishedState(PlayableCharacterController playableCharacterController, PlayerStateMachine playerStateMachine)
            : base(playableCharacterController, playerStateMachine)
        { }


        private float _moveTime = 3f;
        private float _moveAcceleration = 15f;

        private float _moveTimer;


        public override void Enter()
        {
            ReferencesLocator.Instance.FollowingTargetCamera.FollowX = false;

            _controller.CurrentAcceleration = _moveAcceleration;

            _controller.SetAccelerationVector();
            _controller.SetGravity();
            _controller.ApplyVectorsToRigidbody();
        }

        public override void FixedUpdate()
        {
            if (_moveTimer >= _moveTime) { return; }

            _moveTimer += Time.fixedDeltaTime;

            if (_moveTimer >= _moveTime)
            {
                _controller.Rigidbody.velocity = Vector3.zero;
                _controller.Rigidbody.isKinematic = true;
            }
        }
    }
}

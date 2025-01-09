using UnityEngine;

namespace Dimasyechka
{
    public class GroundedState : PlayerState
    {
        public GroundedState(PlayableCharacterController controller, PlayerStateMachine playerStateMachine) : base(controller, playerStateMachine) { }

        public override void Enter() 
        {
            _controller.ContiniousAccelerationTimer = 0;
        }

        public override void FixedUpdate()
        {
            if (_controller.ContiniousAccelerationTimer < _controller.PlayerSettings.StartAccelerationTimer)
            {
                _controller.ContiniousAccelerationTimer += Time.fixedDeltaTime;
            }

            _controller.IsContiniousAccelerating = _controller.ContiniousAccelerationTimer >= _controller.PlayerSettings.StartAccelerationTimer;

            if (_controller.IsContiniousAccelerating)
            {
                _controller.CurrentAcceleration += _controller.PlayerSettings.ContiniousAcceleration * Time.fixedDeltaTime;
            }
            else
            {
                _controller.CurrentAcceleration += _controller.PlayerSettings.StartAcceleration * Time.fixedDeltaTime;
            }

            _controller.SetGravity();
            _controller.SetAccelerationVector();
            _controller.ApplyVectorsToRigidbody();
        }


        public override void Update()
        { 
            if (ReferencesLocator.Instance.InputHandler.JumpActionReference.action.WasPerformedThisFrame())
            {
                _playerStateMachine.SetState(_controller.JumpPreparingState);
            }
        }

        public override void OnCollisionEnter2D(Collision2D collision)
        {
            _controller.DefaultCollisions(collision);
        }
    }
}

using UnityEngine;

namespace Dimasyechka
{
    public class JumpPreparingState : PlayerState
    {
        public float LongJumpTimer { get; private set; } = 0.2f;
        public float ShortJumpTimer { get; private set; } = 0.7f;
        public float HighJumpTimer { get; private set; } = 1f;

        public float JumpingTimer { get; private set; } = 0;

        public JumpPreparingState(PlayableCharacterController controller, PlayerStateMachine playerStateMachine) : base(controller, playerStateMachine) { }

        public override void Enter() 
        {
            JumpingTimer = 0;

            _controller.CurrentAcceleration -= _controller.CurrentAcceleration * 0.3f;
        }

        public override void FixedUpdate()
        {
            _controller.SetGravity();
            _controller.SetAccelerationVector();
            _controller.ApplyVectorsToRigidbody();
        }

        public override void Update()
        {
            if (ReferencesLocator.Instance.InputHandler.JumpActionReference.action.WasPerformedThisFrame())
            {
                if (JumpingTimer <= LongJumpTimer)
                {
                    _playerStateMachine.SetState(_controller.LongJumpingState);
                }
                else if (JumpingTimer <= ShortJumpTimer)
                {
                    _playerStateMachine.SetState(_controller.ShortJumpingState);
                }
                else if (JumpingTimer <= HighJumpTimer)
                {
                    _playerStateMachine.SetState(_controller.HighJumpingState);
                }
                else
                {
                    _playerStateMachine.SetState(_controller.GroundedState);
                }
            }

            JumpingTimer += Time.deltaTime;

            if (JumpingTimer >= 1)
            {
                _playerStateMachine.SetState(_controller.GroundedState);
            }
        }
    }
}

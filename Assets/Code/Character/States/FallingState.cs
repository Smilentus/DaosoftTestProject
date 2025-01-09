using UnityEngine;

namespace Dimasyechka
{
    public class FallingState : PlayerState
    {
        public FallingState(PlayableCharacterController controller, PlayerStateMachine playerStateMachine) : base(controller, playerStateMachine) { }


        public override void Enter()
        {
            _controller.CurrentAcceleration = 0;

            _controller.SetGravity();
            _controller.SetAccelerationVector();
            _controller.ApplyVectorsToRigidbody();

            _controller.Rigidbody.velocity = new Vector2(-2, 2f);
        }

        public override void OnCollisionEnter2D(Collision2D collision)
        {
            _controller.DefaultCollisions(collision);
        }
    }
}

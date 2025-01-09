using UnityEngine;

namespace Dimasyechka
{
    public class JumpingState : PlayerState
    {
        protected float _jumpHeight;
        protected float _jumpWidth;


        public JumpingState(PlayableCharacterController controller, PlayerStateMachine playerStateMachine, float jumpHeight, float jumpWidth) 
            : base(controller, playerStateMachine)
        {
            _jumpHeight = jumpHeight;
            _jumpWidth = jumpWidth;
        }

        public void UpdateValues(float jumpWidth, float jumpHeight)
        {
            _jumpWidth = jumpWidth;
            _jumpHeight = jumpHeight;
        }
        

        public override void Enter()
        {
            _controller.EffectsEmitter.ToggleEmitters(true);

            _controller.Rigidbody.velocity = new Vector2(
                _controller.PlayerWidth * _jumpWidth,
                Mathf.Sqrt(-2 * Physics2D.gravity.y * _controller.PlayerHeight * _jumpHeight)
            );
        }

        public override void Exit()
        {
            _controller.EffectsEmitter.ToggleEmitters(false);

            _controller.SetAccelerationVector();
        }

        public override void OnCollisionEnter2D(Collision2D collision)
        {
            _controller.DefaultCollisions(collision);
        }
    }
}

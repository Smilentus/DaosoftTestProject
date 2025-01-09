using UnityEngine;

namespace Dimasyechka
{
    public class DeathState : PlayerState
    {
        public DeathState(PlayableCharacterController playableCharacterController, PlayerStateMachine playerStateMachine)
            : base(playableCharacterController, playerStateMachine)
        { }


        public override void Enter()
        {
            _controller.Rigidbody.velocity = Vector3.zero;
            _controller.Rigidbody.isKinematic = true;
        }
    }
}

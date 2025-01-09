using UnityEngine;

namespace Dimasyechka
{
    public class HighJumpingState : JumpingState
    {
        public HighJumpingState(PlayableCharacterController controller, PlayerStateMachine playerStateMachine, float jumpHeight, float jumpWidth)
            : base(controller, playerStateMachine, jumpHeight, jumpWidth)
        { }

        public override string ToString()
        {
            return $"High";
        }
    }
}

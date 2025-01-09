using UnityEngine;

namespace Dimasyechka
{
    public class ShortJumpingState : JumpingState
    {
        public ShortJumpingState(PlayableCharacterController controller, PlayerStateMachine playerStateMachine, float jumpHeight, float jumpWidth)
            : base(controller, playerStateMachine, jumpHeight, jumpWidth)
        { }

        public override string ToString()
        {
            return $"Short";
        }
    }
}

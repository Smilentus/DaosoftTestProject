using UnityEngine;

namespace Dimasyechka
{
    public class LongJumpingState : JumpingState
    {
        public LongJumpingState(PlayableCharacterController controller, PlayerStateMachine playerStateMachine, float jumpHeight, float jumpWidth) 
            : base(controller, playerStateMachine, jumpHeight, jumpWidth) 
        { }

        public override string ToString()
        {
            return $"Long";
        }
    }
}

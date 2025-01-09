using UnityEngine;

namespace Dimasyechka
{
    public abstract class PlayerState
    {
        protected readonly PlayerStateMachine _playerStateMachine;
        protected readonly PlayableCharacterController _controller;


        public PlayerState(PlayableCharacterController playableCharacterController, PlayerStateMachine playerStateMachine)
        {
            _playerStateMachine = playerStateMachine;
            _controller = playableCharacterController;
        }


        public virtual void Update() { }
        public virtual void FixedUpdate() { }
        public virtual void Enter() { }
        public virtual void Exit() { }

        public virtual void OnCollisionEnter2D(Collision2D collision) { }
        public virtual void OnCollisionStay2D(Collision2D collision) { }
    }
}
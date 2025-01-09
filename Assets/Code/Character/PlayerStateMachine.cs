using System;
using UnityEngine;

namespace Dimasyechka
{
    public class PlayerStateMachine
    {
        public event Action<PlayerState> OnPlayerStateChanged;


        private PlayerState _currentPlayerState;
        public PlayerState CurrentPlayerState => _currentPlayerState;


        public void Update()
        {
            _currentPlayerState?.Update();
        }

        public void FixedUpdate()
        {
            _currentPlayerState?.FixedUpdate();
        }

        public void OnCollisionEnter2D(Collision2D collision)
        {
            _currentPlayerState?.OnCollisionEnter2D(collision);
        }

        public void OnCollisionStay2D(Collision2D collision)
        {
            _currentPlayerState?.OnCollisionStay2D(collision);
        }

        public void SetState(PlayerState playerState)
        {
            if (playerState == null) return;
            if (playerState == _currentPlayerState) return;

            _currentPlayerState?.Exit();

            _currentPlayerState = playerState;

            _currentPlayerState?.Enter();

            OnPlayerStateChanged?.Invoke(_currentPlayerState);

            //Debug.Log($"State Changed to {_currentPlayerState.GetType().ToString()}");
        }
    }
}

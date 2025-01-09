using System;
using UnityEngine;

namespace Dimasyechka
{
    public class PlayableCharacterController : MonoBehaviour
    {
        public event Action<PlayerState> OnPlayerStateChanged;

        [SerializeField]
        private PlayerEffectsEmitter _effectsEmitter;
        public PlayerEffectsEmitter EffectsEmitter => _effectsEmitter;

        [SerializeField]
        private Rigidbody2D _rigidbody;
        public Rigidbody2D Rigidbody => _rigidbody;

        [SerializeField]
        private LayerMask _groundLayerMask;
        public LayerMask GroundLayerMask => _groundLayerMask;

        [SerializeField]
        private LayerMask _platformBorderLayerMask;
        public LayerMask PlatformBorderLayerMask => _platformBorderLayerMask;

        [SerializeField]
        private PlayerSettings _playerSettings;
        public PlayerSettings PlayerSettings => _playerSettings;


        public GroundedState GroundedState { get; private set; }
        public JumpPreparingState JumpPreparingState { get; private set; }
        public LongJumpingState LongJumpingState { get; private set; }
        public ShortJumpingState ShortJumpingState { get; private set; }
        public HighJumpingState HighJumpingState { get; private set; }
        public FallingState FallingState { get; private set; }
        public DeathState DeathState { get; private set; }
        public LevelFinishedState LevelFinishedState { get; private set; }


        private PlayerStateMachine _stateMachine;


        public float ContiniousAccelerationTimer { get; set; } = 0;
        public float CurrentAcceleration { get; set; } = 0f;
        public bool IsContiniousAccelerating { get; set; } = false;


        public float PlayerHeight => this.transform.localScale.y;
        public float PlayerWidth => this.transform.localScale.x;


        public Vector2 GravityVector { get; private set; }
        public Vector2 AccelerationVector { get; private set; }


        private void Awake()
        {
            SetupStateMachine();
        }

        private void Update()
        {
            _stateMachine.Update();
        }

        private void FixedUpdate()
        {
            _stateMachine.FixedUpdate();

            if (Rigidbody.velocity.magnitude >= _playerSettings.MaxVelocity)
            {
                Rigidbody.velocity = Rigidbody.velocity.normalized * _playerSettings.MaxVelocity;
            }
        }


        private void OnEnable()
        {
            _stateMachine.OnPlayerStateChanged += PlayerStateChanged;
        }

        private void OnDisable()
        {
            _stateMachine.OnPlayerStateChanged -= PlayerStateChanged;
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            _stateMachine.OnCollisionEnter2D(collision);
        }

        private void OnCollisionStay2D(Collision2D collision)
        {
            _stateMachine.OnCollisionStay2D(collision);
        }

        public void DefaultCollisions(Collision2D collision)
        {
            if (LayerCheckerUtility.IsInLayer(collision.gameObject, GroundLayerMask))
            {
                _stateMachine.SetState(GroundedState);
            }
            else if (LayerCheckerUtility.IsInLayer(collision.gameObject, PlatformBorderLayerMask))
            {
                _stateMachine.SetState(FallingState);
            }
        }


        private void PlayerStateChanged(PlayerState state)
        {
            OnPlayerStateChanged?.Invoke(state);
        }


        private void SetupStateMachine()
        {
            _stateMachine = new PlayerStateMachine();

            GroundedState = new GroundedState(this, _stateMachine);
            JumpPreparingState = new JumpPreparingState(this, _stateMachine);
            LongJumpingState = new LongJumpingState(this, _stateMachine, _playerSettings.LongJumpHeight, _playerSettings.LongJumpWidth);
            ShortJumpingState = new ShortJumpingState(this, _stateMachine, _playerSettings.ShortJumpHeight, _playerSettings.ShortJumpWidth);
            HighJumpingState = new HighJumpingState(this, _stateMachine, _playerSettings.HighJumpHeight, _playerSettings.HighJumpWidth);
            FallingState = new FallingState(this, _stateMachine);
            DeathState = new DeathState(this, _stateMachine);
            LevelFinishedState = new LevelFinishedState(this, _stateMachine);

            _stateMachine.SetState(GroundedState);
        }

        public bool IsDead() => _stateMachine.CurrentPlayerState == DeathState;

        public void SetDeathState()
        {
            _stateMachine.SetState(DeathState);
        }

        public void SetFinishedState()
        {
            _stateMachine.SetState(LevelFinishedState);
        }

        public void SetGravity()
        {
            if (Rigidbody.velocity.y < 0)
            {
                GravityVector = Vector2.up * Physics2D.gravity.y;
            }
            else
            {
                GravityVector = Vector2.zero;
            }
        }

        public void SetAccelerationVector()
        {
            AccelerationVector = Vector2.right * CurrentAcceleration;
        }

        public void ApplyVectorsToRigidbody()
        {
            Rigidbody.velocity = AccelerationVector + GravityVector;
        }

        public void ApplyRuntimeTunableSettings(TunableSettings settings)
        {
            HighJumpingState.UpdateValues(settings.HighWidth, settings.HighHeight);
            ShortJumpingState.UpdateValues(settings.ShortWidth, settings.ShortHeight);
            LongJumpingState.UpdateValues(settings.LongWidth, settings.LongHeight);
        }
    }
}

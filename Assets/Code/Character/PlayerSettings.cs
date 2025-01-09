using UnityEngine;

namespace Dimasyechka
{
    [CreateAssetMenu(fileName = "PlayerSettings", menuName = "Project/Create New PlayerSettings")]
    public class PlayerSettings : ScriptableObject
    {
        [Header("Acceleration Settings")]
        [SerializeField]
        private float _startAcceleration = 0.8f;
        public float StartAcceleration
        {
            get => _startAcceleration;
            set => _startAcceleration = value;
        }

        [SerializeField]
        private float _continiousAcceleration = 0.3f;
        public float ContiniousAcceleration
        {
            get => _continiousAcceleration;
            set => _continiousAcceleration = value;
        }


        [SerializeField]
        private float _startAccelerationTimer = 4f;
        public float StartAccelerationTimer
        {
            get => _startAccelerationTimer;
            set => _startAccelerationTimer = value;
        }

        [SerializeField]
        private float _maxVelocity = 100f;
        public float MaxVelocity
        {
            get => _maxVelocity;
            set => _maxVelocity = value;
        }


        [Header("Long Jump Settings")]
        [SerializeField]
        private float _longJumpHeight = 1f;
        public float LongJumpHeight
        {
            get => _longJumpHeight;
            set => _longJumpHeight = value;
        }

        [SerializeField]
        private float _longJumpWidth = 2f;
        public float LongJumpWidth
        {
            get => _longJumpWidth;
            set => _longJumpWidth = value;
        }

        [Header("Short Jump Settings")]
        [SerializeField]
        private float _shortJumpHeight = 1f;
        public float ShortJumpHeight
        {
            get => _shortJumpHeight;
            set => _shortJumpHeight = value;
        }

        [SerializeField]
        private float _shortJumpWidth = 1f;
        public float ShortJumpWidth
        {
            get => _shortJumpWidth;
            set => _shortJumpWidth = value;
        }

        [Header("High Jump Settings")]
        [SerializeField]
        private float _highJumpHeight = 2f;
        public float HighJumpHeight
        {
            get => _highJumpHeight;
            set => _highJumpHeight = value;
        }

        [SerializeField]
        private float _highJumpWidth = 1f;
        public float HighJumpWidth
        {
            get => _highJumpWidth;
            set => _highJumpWidth = value;
        }
    }
}

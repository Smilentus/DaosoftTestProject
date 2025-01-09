using UnityEngine;

namespace Dimasyechka
{
    public class RuntimePlayerTuner : MonoBehaviour
    {
        [SerializeField]
        private PlayerSettings _playerSettings;
        public PlayerSettings PlayerSettings => _playerSettings;


        public void ApplySettings(TunableSettings settings)
        {
            _playerSettings.StartAcceleration = settings.StartAcceleration;
            _playerSettings.ContiniousAcceleration = settings.ContiniousAcceleration;

            _playerSettings.LongJumpHeight = settings.LongHeight;
            _playerSettings.LongJumpWidth= settings.LongWidth;

            _playerSettings.ShortJumpHeight = settings.ShortHeight;
            _playerSettings.ShortJumpWidth = settings.ShortWidth;
            
            _playerSettings.HighJumpWidth = settings.HighWidth;
            _playerSettings.HighJumpHeight = settings.HighHeight;

            ReferencesLocator.Instance.PlayableCharacterController.ApplyRuntimeTunableSettings(settings);
        }
    }

    public struct TunableSettings
    {
        public float StartAcceleration;
        public float ContiniousAcceleration;

        public float LongWidth;
        public float LongHeight;

        public float ShortWidth;
        public float ShortHeight;

        public float HighWidth;
        public float HighHeight;
    }
}

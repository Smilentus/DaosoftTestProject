using UnityEngine;

namespace Dimasyechka
{
    public class BasePlayerStateView : MonoBehaviour
    {
        protected PlayableCharacterController _playableCharacterController;


        private void OnEnable()
        {
            _playableCharacterController = ReferencesLocator.Instance.PlayableCharacterController;

            if (_playableCharacterController != null)
            {
                _playableCharacterController.OnPlayerStateChanged += PlayerStateChanged;
            }
        }

        private void OnDisable()
        {
            if (_playableCharacterController != null)
            {
                _playableCharacterController.OnPlayerStateChanged -= PlayerStateChanged;
            }
        }

        protected virtual void PlayerStateChanged(PlayerState state) { }
    }
}

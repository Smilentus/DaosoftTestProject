using UnityEngine;
using UnityEngine.InputSystem;

namespace Dimasyechka
{
    public class InputHandler : MonoBehaviour
    {
        [SerializeField]
        private InputActionReference _jumpActionReference;
        public InputActionReference JumpActionReference => _jumpActionReference;

        [SerializeField]
        private InputActionReference _reloadSceneActionReference;
        public InputActionReference ReloadSceneActionReference => _reloadSceneActionReference;

        [SerializeField]
        private InputActionReference _debugMenuActionReference;
        public InputActionReference DebugMenuActionReference => _debugMenuActionReference;


        private void OnEnable()
        {
            EnableActions();
        }

        private void OnDisable()
        {
            DisableActions();
        }


        public void EnableActions()
        {
            _jumpActionReference.action.Enable();
            _reloadSceneActionReference.action.Enable();
            _debugMenuActionReference.action.Enable();
        }

        public void DisableActions()
        {
            _jumpActionReference.action.Disable();
            _reloadSceneActionReference.action.Disable();
            _debugMenuActionReference.action.Disable();
        }
    }
}

using UnityEngine;

namespace Dimasyechka
{
    public class ReferencesLocator : MonoBehaviour
    {
        private static ReferencesLocator _instance;
        public static ReferencesLocator Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = FindObjectOfType<ReferencesLocator>();
                }

                return _instance;
            }
        }


        [field: SerializeField]
        public PlayableCharacterController PlayableCharacterController { get; private set; }

        [field: SerializeField]
        public FollowingTargetCamera FollowingTargetCamera { get; private set; }

        [field: SerializeField]
        public InputHandler InputHandler { get; private set; }
    }
}

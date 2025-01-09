using UnityEditor;
using UnityEngine;

namespace Dimasyechka
{
    public class PlayableCharacterLevelHeightLimiter : MonoBehaviour
    {
        [SerializeField]
        private PlayableCharacterController _playableCharacterController;


        [Tooltip("ќграничение уровн€ по Y (ниже этого значени€ = смерть)")]
        [SerializeField]
        private float _levelDeath = -10f;
        

        private void FixedUpdate()
        {
            if (_playableCharacterController == null) return;
            if (_playableCharacterController.IsDead()) return;

            if (_playableCharacterController.transform.position.y <= _levelDeath)
            {
                _playableCharacterController.SetDeathState();   
            }
        }


        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawLine(new Vector3(-1000, _levelDeath, 0), new Vector3(1000, _levelDeath, 0));

            Handles.color = Color.white;
            Handles.Label(new Vector3(0, _levelDeath, 0), new GUIContent("--- Death Line ---"));
        }
    }
}

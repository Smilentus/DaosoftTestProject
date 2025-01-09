using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
#endif

namespace Dimasyechka
{
    public class PlayableCharacterLevelHeightLimiter : MonoBehaviour
    {
        [SerializeField]
        private PlayableCharacterController _playableCharacterController;


        [Tooltip("����������� ������ �� Y (���� ����� �������� = ������)")]
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

#if UNITY_EDITOR
        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawLine(new Vector3(-1000, _levelDeath, 0), new Vector3(1000, _levelDeath, 0));

            Handles.color = Color.white;
            Handles.Label(new Vector3(0, _levelDeath, 0), new GUIContent("--- Death Line ---"));
        }
#endif
    }
}

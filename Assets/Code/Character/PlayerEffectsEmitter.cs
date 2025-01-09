using UnityEngine;

namespace Dimasyechka
{
    public class PlayerEffectsEmitter : MonoBehaviour
    {
        [SerializeField]
        private TrailRenderer[] _trailRenderers;


        public void ToggleEmitters(bool value)
        {
            foreach (var renderer in _trailRenderers)
            {
                renderer.emitting = value;
            }
        }
    }
}

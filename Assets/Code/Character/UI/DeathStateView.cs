using UnityEngine;

namespace Dimasyechka
{
    public class DeathStateView : BasePlayerStateView
    {
        [SerializeField]
        private GameObject _content;


        private void Awake()
        {
            _content.SetActive(false);
        }


        protected override void PlayerStateChanged(PlayerState state)
        {
            if (state == null) return;

            _content.SetActive(state.GetType().Equals(typeof(DeathState)));
        }
    }
}

using UnityEngine;

namespace Dimasyechka
{
    public class FinishArea : TriggerArea
    {
        [SerializeField]
        private LayerMask _playerMask;

        public override void OnEnter(Collider2D collision)
        {
            if (LayerCheckerUtility.IsInLayer(collision.gameObject, _playerMask))
            {
                Debug.Log("Level Finished");

                var controller = collision.GetComponent<PlayableCharacterController>();

                if (controller != null)
                {
                    controller.SetFinishedState();
                }

                base.OnEnter(collision);
            }
        }
    }
}

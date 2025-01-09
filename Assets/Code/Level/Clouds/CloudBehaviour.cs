using UnityEngine;

namespace Dimasyechka
{
    public class CloudBehaviour : MonoBehaviour
    {
        [SerializeField]
        private float _moveSpeed = 1f;


        [SerializeField]
        private SpriteRenderer _renderer;


        public void SetupRandomOrder(int order)
        {
            _renderer.sortingOrder = order;
        }

        public void SetupRandomMoveSpeed(float speed)
        {
            _moveSpeed = speed;
        }

        public void Move()
        {
            this.transform.position += Vector3.left * _moveSpeed * Random.Range(_moveSpeed * 0.95f, _moveSpeed * 1.05f) * Time.fixedDeltaTime;
        }

        public void MarkToDestroy()
        {
            Destroy(this.gameObject, 3f);
        }
    }
}

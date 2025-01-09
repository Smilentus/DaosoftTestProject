using UnityEngine;

namespace Dimasyechka
{
    public class PlatformBehaviour : MonoBehaviour
    {
        [Header("References")]
        [SerializeField]
        private SpriteRenderer _renderer;

        [SerializeField]
        private BoxCollider2D _mainCollider;

        [SerializeField]
        private BoxCollider2D _leftBorder;

        [SerializeField]
        private BoxCollider2D _bottomBorder;


        [Header("Settings")]
        [SerializeField]
        private float _borderThickness = 0.1f;


        public void Setup(Vector2 size)
        {
            _renderer.size = size;
            _renderer.transform.localPosition = new Vector3(_renderer.size.x / 2f, 0, 0);

            _mainCollider.size = new Vector2(
                size.x,
                size.y - _borderThickness
            );
            _mainCollider.offset = new Vector2(0, _borderThickness * 0.5f);

            _leftBorder.transform.localPosition = new Vector3(size.x * -0.5f + _borderThickness * 0.5f, -_borderThickness * 0.25f, 0);
            _leftBorder.size = new Vector2(_borderThickness, size.y - _borderThickness * 0.5f);

            _bottomBorder.transform.localPosition = new Vector3(0, size.y * -0.5f - _borderThickness, 0);
            _bottomBorder.size = new Vector2(size.x - _borderThickness, _borderThickness);
            _bottomBorder.offset = new Vector2(0.05f, _borderThickness * 1.5f);
        }
    }
}

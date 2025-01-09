using UnityEngine;

namespace Dimasyechka
{
    public class RuntimeLevelGenerator : MonoBehaviour
    {
        [SerializeField]
        private PlayableCharacterController _playableCharacterController;

        [SerializeField]
        private Transform _zeroPoint;

        [SerializeField]
        private PlatformBehaviour _platformPrefab;

        [SerializeField]
        private GameObject _finishAreaPrefab;


        [Header("Settings")]
        [SerializeField]
        private int _platformsCount = 25;


        private void Start()
        {
            float spawnPointX = _zeroPoint.position.x;

            for (int i = 0; i < _platformsCount; i++)
            {
                float platformWidth = _playableCharacterController.PlayerWidth * 0.8f * Random.Range(3, 6);
                float platformGap = _playableCharacterController.PlayerWidth * Random.Range(2, 4);

                Vector3 spawnPos = new Vector3(
                    spawnPointX,
                    Random.Range(_zeroPoint.position.y + _playableCharacterController.PlayerHeight * 0.5f, _zeroPoint.position.y + _playableCharacterController.PlayerHeight * 1.5f), 
                    0
                );

                PlatformBehaviour platform = Instantiate(_platformPrefab, spawnPos, Quaternion.identity);

                platform.Setup(new Vector2(
                    platformWidth,
                    _playableCharacterController.PlayerHeight * 0.1f)
                );

                spawnPointX += platformWidth + platformGap;
            }

            GameObject finishArea = Instantiate(_finishAreaPrefab, new Vector3(spawnPointX, 0, 0), Quaternion.identity);
        }
    }
}

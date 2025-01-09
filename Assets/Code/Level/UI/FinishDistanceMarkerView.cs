using System.Collections;
using TMPro;
using UnityEngine;

namespace Dimasyechka
{
    public class FinishDistanceMarkerView : MonoBehaviour
    {
        [SerializeField]
        private TMP_Text _markerTMP;


        private FinishArea _finishArea;


        public float DistanceToFinish { get; private set; }


        private void Start()
        {
            StartCoroutine(FindFinishAreaProcess());
        }

        private void OnDestroy()
        {
            StopAllCoroutines();
        }


        private void FixedUpdate()
        {
            CalculateDistance();
        }


        private void CalculateDistance()
        {
            if (_finishArea == null) return;

            Vector3 playerPosition = ReferencesLocator.Instance.PlayableCharacterController.transform.position;

            if (playerPosition.x < _finishArea.transform.position.x)
            {
                DistanceToFinish = Vector3.Distance(playerPosition, _finishArea.transform.position);
            }
            else
            {
                DistanceToFinish = 0;
            }

            _markerTMP.text = $"Расстояние до финиша: {DistanceToFinish.ToString("f2")}";
        }


        private IEnumerator FindFinishAreaProcess()
        {
            while (true)
            {
                _finishArea = FindObjectOfType<FinishArea>();

                if (_finishArea != null) break;

                yield return new WaitForSeconds(0.1f);
            }
        }
    }
}

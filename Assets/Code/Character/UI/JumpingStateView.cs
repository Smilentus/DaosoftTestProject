using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using DG.Tweening;

namespace Dimasyechka
{
    public class JumpingStateView : BasePlayerStateView
    {
        [Header("References")]
        [SerializeField]
        private Transform _content;

        [SerializeField]
        private CanvasGroup _contentCanvasGroup;

        [SerializeField]
        private Image _jumpImage;

        [SerializeField]
        private TMP_Text _jumpText;

        [SerializeField]
        private Transform _divisionLinePrefab;


        [Header("Color Settings")]
        [SerializeField]
        private Color _initialColor;

        [SerializeField]
        private Color _endColor;


        private List<Transform> _divisionLines = new List<Transform>();

        private bool _isJumpPreparing = false;


        private Tweener _fadeTweener;


        private void Start()
        {
            FillDivisionLines();
            _content.gameObject.SetActive(false);
        }


        private void Update()
        {
            UpdateJumpIcon();
        }


        private void Show()
        {
            _content.gameObject.SetActive(true);
         
            if (_fadeTweener != null)
            {
                _fadeTweener.Kill();
            }

            _fadeTweener = _contentCanvasGroup.DOFade(1, 0.05f);
        }

        private void Hide()
        {
            if (_fadeTweener != null)
            {
                _fadeTweener.Kill();
            }

            _fadeTweener = _contentCanvasGroup.DOFade(0, 0.05f).OnComplete(() => {
                _content.gameObject.SetActive(false);
            });
        }


        private void FillDivisionLines()
        {
            for (int i = _jumpImage.transform.childCount - 1; i >= 0; i--)
            {
                Destroy(_jumpImage.transform.GetChild(i).gameObject);
            }

            _divisionLines.Clear();

            for (int i = 0; i < 2; i++)
            {
                Transform divisionLine = Instantiate(_divisionLinePrefab, _jumpImage.transform);

                _divisionLines.Add(divisionLine);
            }

            CalculateDivisions();
        }


        protected override void PlayerStateChanged(PlayerState state)
        {
            if (state == null) return;

            if (state.GetType().Equals(typeof(JumpPreparingState)))
            {
                CalculateDivisions();

                _isJumpPreparing = true;

                Show();
            }
            else
            {
                _isJumpPreparing = false;

                Hide();
            }
        }

        private void UpdateJumpIcon()
        {
            if (!_isJumpPreparing) return;

            UpdateJumpBar();
        }

        private void CalculateDivisions()
        {
            float max = GetMaxJumpTimings();
            float longJumpRatio = _playableCharacterController.JumpPreparingState.LongJumpTimer / max;
            float shortJumpRatio = _playableCharacterController.JumpPreparingState.ShortJumpTimer / max;
            float highJumpRatio = _playableCharacterController.JumpPreparingState.HighJumpTimer / max;

            float rectHeight = _jumpImage.GetComponent<RectTransform>().rect.height;

            _divisionLines[0].localPosition = new Vector3(0, longJumpRatio * rectHeight - rectHeight * 0.5f, 0);
            _divisionLines[1].localPosition = new Vector3(0, shortJumpRatio * rectHeight - rectHeight * 0.5f, 0);
        }

        private void UpdateJumpBar()
        {
            float max = GetMaxJumpTimings();

            float jumpRatio = _playableCharacterController.JumpPreparingState.JumpingTimer / max;
            float longJumpRatio = _playableCharacterController.JumpPreparingState.LongJumpTimer / max;
            float shortJumpRatio = _playableCharacterController.JumpPreparingState.ShortJumpTimer / max;
            float highJumpRatio = _playableCharacterController.JumpPreparingState.HighJumpTimer / max;

            if (jumpRatio <= longJumpRatio)
            {
                _jumpText.text = _playableCharacterController.LongJumpingState.ToString();
            }
            else if (jumpRatio <= shortJumpRatio)
            {
                _jumpText.text = _playableCharacterController.ShortJumpingState.ToString();
            }
            else
            {
                _jumpText.text = _playableCharacterController.HighJumpingState.ToString();
            }

            _jumpImage.fillAmount = jumpRatio;

            _jumpImage.color = Color.Lerp(_initialColor, _endColor, jumpRatio);
        }

        private float GetMaxJumpTimings()
        {
            return Mathf.Max(
                Mathf.Max(
                    _playableCharacterController.JumpPreparingState.LongJumpTimer,
                    _playableCharacterController.JumpPreparingState.ShortJumpTimer
                ),
                _playableCharacterController.JumpPreparingState.HighJumpTimer
            );
        }
    }
}

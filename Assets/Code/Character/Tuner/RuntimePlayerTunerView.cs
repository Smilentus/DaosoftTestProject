using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Dimasyechka
{
    public class RuntimePlayerTunerView : MonoBehaviour
    {
        [SerializeField]
        private RuntimePlayerTuner _runtimePlayerTuner;


        [SerializeField]
        private GameObject _content;


        [SerializeField]
        private Button _applyButton;


        [SerializeField]
        private TMP_InputField _firstAcceleration;

        [SerializeField]
        private TMP_InputField _secondAcceleration;


        [SerializeField]
        private TMP_InputField _highJumpWidth;

        [SerializeField]
        private TMP_InputField _highJumpHeight;


        [SerializeField]
        private TMP_InputField _shortJumpWidth;

        [SerializeField]
        private TMP_InputField _shortJumpHeight;


        [SerializeField]
        private TMP_InputField _longJumpWidth;

        [SerializeField]
        private TMP_InputField _longJumpHeight;


        private void Start()
        {
            _content.SetActive(false);
        }

        private void OnEnable()
        {
            _applyButton.onClick.AddListener(ApplySettings);
        }

        private void OnDisable()
        {
            _applyButton.onClick.RemoveListener(ApplySettings);
        }

        private void Update()
        {
            if (ReferencesLocator.Instance.InputHandler.DebugMenuActionReference.action.WasPerformedThisFrame())
            {
                _content.SetActive(!_content.activeSelf);
                
                if (_content.activeSelf)
                {
                    LoadSettings();
                }
            }
        }


        public void LoadSettings()
        {
            _firstAcceleration.text = _runtimePlayerTuner.PlayerSettings.StartAcceleration.ToString();
            _secondAcceleration.text = _runtimePlayerTuner.PlayerSettings.ContiniousAcceleration.ToString();

            _highJumpHeight.text = _runtimePlayerTuner.PlayerSettings.HighJumpHeight.ToString();
            _highJumpWidth.text = _runtimePlayerTuner.PlayerSettings.HighJumpWidth.ToString();

            _shortJumpHeight.text = _runtimePlayerTuner.PlayerSettings.ShortJumpHeight.ToString();
            _shortJumpWidth.text = _runtimePlayerTuner.PlayerSettings.ShortJumpWidth.ToString();

            _longJumpHeight.text = _runtimePlayerTuner.PlayerSettings.LongJumpHeight.ToString();
            _longJumpWidth.text = _runtimePlayerTuner.PlayerSettings.LongJumpWidth.ToString();
        }

        
        public void ApplySettings()
        {
            TunableSettings settings = new TunableSettings();

            settings.StartAcceleration = float.Parse(_firstAcceleration.text);
            settings.ContiniousAcceleration = float.Parse(_secondAcceleration.text);

            settings.HighHeight = float.Parse(_highJumpHeight.text);
            settings.HighWidth = float.Parse(_highJumpWidth.text);

            settings.ShortHeight = float.Parse(_shortJumpHeight.text);
            settings.ShortWidth = float.Parse(_shortJumpWidth.text);

            settings.LongHeight = float.Parse(_longJumpHeight.text);
            settings.LongWidth = float.Parse(_longJumpWidth.text);

            _runtimePlayerTuner.ApplySettings(settings);

            _content.SetActive(false);
        }
    }
}

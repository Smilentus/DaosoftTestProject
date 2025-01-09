using UnityEngine;
using UnityEngine.SceneManagement;

namespace Dimasyechka
{
    public class SceneReloader : MonoBehaviour
    {
        private bool _isReloading = false;


        private void Update()
        {
            if (_isReloading) return;

            if (ReferencesLocator.Instance.InputHandler.ReloadSceneActionReference.action.WasPerformedThisFrame())
            {
                _isReloading = true;

                ReloadActiveScene();
            }
        }


        public void ReloadActiveScene()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}

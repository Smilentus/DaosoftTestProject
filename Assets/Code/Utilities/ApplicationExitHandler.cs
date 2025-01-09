using UnityEngine;

namespace Dimasyechka
{
    public class ApplicationExitHandler : MonoBehaviour
    {
        private void Update()
        {
            if (Input.GetKey(KeyCode.Escape))
            {
                Application.Quit();
            }
        }
    }
}

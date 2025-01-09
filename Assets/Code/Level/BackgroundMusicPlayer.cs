using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Dimasyechka
{
    public class BackgroundMusicPlayer : MonoBehaviour
    {
        [SerializeField]
        private AudioSource _audioSource;


        private void OnEnable()
        {
            _audioSource.Play();
        }

        private void OnDisable()
        {
            _audioSource.Stop();
        }
    }
}

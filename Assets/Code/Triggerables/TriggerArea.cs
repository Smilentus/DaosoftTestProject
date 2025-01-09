using System;
using UnityEngine;

namespace Dimasyechka
{
    public class TriggerArea : MonoBehaviour
    {
        public event Action<Collider2D> onTriggerEnter;
        public event Action<Collider2D> onTriggerExit;
        public event Action<Collider2D> onTriggerStay;


        private void OnTriggerEnter2D(Collider2D collision)
        {
            OnEnter(collision);
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            OnExit(collision);
        }

        private void OnTriggerStay2D(Collider2D collision)
        {
            OnStay(collision);
        }


        public virtual void OnEnter(Collider2D collision) 
        {
            onTriggerEnter?.Invoke(collision);
        }

        public virtual void OnExit(Collider2D collision)
        {
            onTriggerExit?.Invoke(collision);
        }

        public virtual void OnStay(Collider2D collision)
        {
            onTriggerStay?.Invoke(collision);
        }
    }
}

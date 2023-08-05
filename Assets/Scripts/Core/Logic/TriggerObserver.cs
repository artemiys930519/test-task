using System;
using UnityEngine;

namespace Core.Logic
{
    public class TriggerObserver : MonoBehaviour
    {
        private const string PlayerTag = "Player";
        public event Action TriggerEnter;

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag(PlayerTag))
                TriggerEnter?.Invoke();
        }
    }
}
using System;
using UnityEngine;

namespace Scripts
{
    public class PerfocardCounterTrigger : MonoBehaviour
    {
        public event Action<Collider> ObjectEnteredInTrigger;


        private void OnTriggerEnter(Collider other)
        {
            ObjectEnteredInTrigger?.Invoke(other);
        }
    }
}
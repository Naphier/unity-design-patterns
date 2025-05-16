using UnityEngine;
using UnityEngine.Events;

namespace logandlp.Observer
{
    using Message;
    
    public class Observers : MonoBehaviour
    {
        [SerializeField] private Messages _messages;
        [SerializeField] private UnityEvent _callbacks;

        private void OnEnable()
        {
            _messages.Message += InvokeCallbacks;
        }

        private void OnDisable()
        {
            _messages.Message -= InvokeCallbacks;
        }

        private void InvokeCallbacks()
        {
            _callbacks?.Invoke();
        }
    }
}


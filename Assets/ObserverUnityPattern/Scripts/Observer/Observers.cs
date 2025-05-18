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
            // Subscribe event.
            _messages.Message += InvokeCallbacks;
        }

        private void OnDisable()
        {
            // Unsubscribe event.
            _messages.Message -= InvokeCallbacks;
        }

        // If the message contains a type the method must contain an overload of this same type as well as the Unity Event "UnityEvent<T>".
        private void InvokeCallbacks()
        {
            _callbacks?.Invoke();
        }
    }
}


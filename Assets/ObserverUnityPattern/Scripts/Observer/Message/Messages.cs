using System;
using UnityEngine;

namespace logandlp.Observer.Message
{
    [CreateAssetMenu(fileName = "new_" + nameof(Message), menuName = "Observers/Messages")]
    public class Messages : ScriptableObject
    {
        // The message can contain type with Action<T>.
        public Action Message { get; set; }

        // If the message contains a type the method must contain an overload of this same type.
        public void InvokeMessages()
        {
            Message?.Invoke();
        }
    }
}


using System;
using UnityEngine;

namespace logandlp.Observer.Message
{
    [CreateAssetMenu(fileName = "new_" + nameof(Message), menuName = "Observers/Messages")]
    public class Messages : ScriptableObject
    {
        public Action Message { get; set; }

        public void InvokeMessages()
        {
            Message?.Invoke();
        }
    }
}


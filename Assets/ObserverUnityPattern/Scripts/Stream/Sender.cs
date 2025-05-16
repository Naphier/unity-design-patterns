using UnityEngine;

namespace logandlp.Stream
{
    using Observer.Message;
    
    public class Sender : MonoBehaviour
    {
        [SerializeField] private Messages _messages;

        [ContextMenu("Send Message")]
        public void SendMessage()
        {
            _messages?.InvokeMessages();
        }
    }
}
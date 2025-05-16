using UnityEngine;

namespace logandlp.Stream
{
    public class Receiver : MonoBehaviour
    {
        public void ReceiveMessage()
        {
            Debug.Log($"'{gameObject.name}' received message !");
        }
    }
}
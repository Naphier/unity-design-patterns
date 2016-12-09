using System;
using UnityEngine;

namespace NG.Patterns.Structure.ObserverPattern
{
    public class BaseBehaviour : MonoBehaviour
    {
        internal void OnHandlerMessage(ObservParam observParam, Action<ObservParam> value)
        {
            value(observParam);
        }
    }
}


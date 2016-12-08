using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseBehaviour : MonoBehaviour {

    internal void OnHandlerMessage(ObservParam observParam, Action<ObservParam> value)
    {
        value(observParam);
    }
}

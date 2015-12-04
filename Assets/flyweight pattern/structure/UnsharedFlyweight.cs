using UnityEngine;
using System.Collections;
using System;

public class UnsharedFlyweight : FlyweightBase
{
    private object _state;

    public override void StatefulOperation(object obj)
    {
        _state = obj;
        Debug.Log("Unshared flyweight StatefulOperation: " + _state.ToString());
    }
}

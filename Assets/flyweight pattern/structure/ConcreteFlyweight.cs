using UnityEngine;

public class ConcreteFlyweight : FlyweightBase
{

    public override void StatefulOperation(object obj)
    {
        Debug.Log("Not implememnted - object: " + obj.ToString());
    }
}


namespace NG.Flyweight.Structure
{
    public class ConcreteFlyweight : FlyweightBase
    {

        public override void StatefulOperation(object obj)
        {
            UnityEngine.Debug.Log("Not implemented - object: " + obj.ToString());
        }
    }
}

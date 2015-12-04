namespace NG.Flyweight.Structure
{
    public class UnsharedFlyweight : FlyweightBase
    {
        private object _state;

        public override void StatefulOperation(object obj)
        {
            _state = obj;
            UnityEngine.Debug.Log("Unshared flyweight StatefulOperation: " + _state.ToString());
        }
    }

}

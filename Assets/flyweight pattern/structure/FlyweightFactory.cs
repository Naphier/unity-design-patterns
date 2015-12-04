using System.Collections;
namespace NG.Flyweight.Structure
{
    public class FlyweightFactory
    {
        private Hashtable _flyweights = new Hashtable();

        public FlyweightBase GetFlyweight(string key)
        {
            if (_flyweights.Contains(key))
            {
                return _flyweights[key] as FlyweightBase;
            }
            else
            {
                ConcreteFlyweight newFlyweight = new ConcreteFlyweight();

                // Set flyweight's properties here.

                _flyweights.Add(key, newFlyweight);
                return newFlyweight;
            }
        }
    }
}

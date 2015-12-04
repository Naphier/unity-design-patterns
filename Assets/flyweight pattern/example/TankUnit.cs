using System;
using UnityEngine;

namespace NG.Flyweight.Example
{
    public class Tank : Unit
    {
        public Tank()
        {
            uUnitType = UnitType.Tank;
            Name = uUnitType.ToString();
        }

        public override void FireAt(Guid targetID)
        {
            //UnityEngine.Debug.LogFormat(uUnitType.ToString() + ": Firing at targetID {0} with power of {1}.", targetID, FirePower);

            BulletBehaviour bb = FlyweightTest.MakeBullet(targetId, gameObject);
            bb.firePower = FirePower;
            bb.range = Range;
        }

        public override GameObject Instantiate(GameObject prefab)
        {
            GameObject newUnit = GameObject.Instantiate(prefab);
            newUnit.name = Name;
            return newUnit;
        }
    }
}


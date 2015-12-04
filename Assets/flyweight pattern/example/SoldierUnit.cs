using System;
using UnityEngine;

public class Soldier : Unit
{
    public Soldier(UnitType soldierType)
    {
        if (soldierType != UnitType.Infantry && soldierType != UnitType.Marine)
            throw new System.ArgumentException("Cannot create soldier with UnitType = " + soldierType.ToString());

        Name = soldierType.ToString();
        uUnitType = soldierType;
    }

    public override void FireAt(Guid targetID)
    {
        //UnityEngine.Debug.LogFormat(uUnitType.ToString() + ": Shooting at targetID {0} with power of {1}.", targetID, FirePower);
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

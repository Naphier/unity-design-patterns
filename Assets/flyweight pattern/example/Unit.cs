using System;
using UnityEngine;

public abstract class Unit
{
    public string Name { get; internal set; }
    public UnitType uUnitType { get; internal set; }

    public GameObject gameObject { get; internal set; }
    public int Armor { get; internal set; }
    public int Speed { get; internal set; }
    public int RotationRate { get; internal set; }
    public int FireRate { get; internal set; }
    public int Range { get; internal set; }
    public int FirePower { get; internal set; }
    public Guid ID { get; internal set; }
    public Guid targetId { get; internal set; }
    public UnitMonobehaviour unitMonobehaviour { get; internal set; }


    private float lastShotTime = 0f;

    public abstract void FireAt(Guid targetID);

    public abstract GameObject Instantiate(GameObject prefab);

    public bool CanShoot()
    {
        if (Time.time - lastShotTime > (1f /FireRate))
        {
            lastShotTime = Time.time;
            return true;
        }
        else
            return false;
    }
}

public enum UnitType
{ Infantry, Marine, Tank}


public static class UnitExtension
{
    public static string ToString(this UnitType unitType)
    {
        switch (unitType)
        {
            case UnitType.Infantry:
                return "Infantry";
            case UnitType.Marine:
                return "Marine";
            case UnitType.Tank:
                return "Tank";
            default:
                throw new System.ArgumentException();
        }
    }
}


using System;
using System.Collections.Generic;
using UnityEngine;

namespace NG.Flyweight.Example
{
    public class UnitFactory
    {
        private Dictionary<UnitType, Unit> _units = new Dictionary<UnitType, Unit>();

        public Unit GetUnit(UnitType unitType)
        {
            if (_units.ContainsKey(unitType))
            {
                return _units[unitType];
            }
            else
            {
                Unit unit = null;
                switch (unitType)
                {
                    case UnitType.Infantry:
                        unit = new Soldier(unitType);
                        unit.Armor = 50;
                        unit.Speed = 4;
                        unit.RotationRate = 180;
                        unit.FireRate = 5;
                        unit.Range = 40;
                        unit.FirePower = 5;
                        break;
                    case UnitType.Marine:
                        unit = new Soldier(unitType);
                        unit.Armor = 250;
                        unit.Speed = 4;
                        unit.RotationRate = 180;
                        unit.FireRate = 3;
                        unit.Range = 40;
                        unit.FirePower = 10;
                        break;
                    case UnitType.Tank:
                        unit = new Tank();
                        unit.Armor = 1000;
                        unit.Speed = 25;
                        unit.RotationRate = 5;
                        unit.FireRate = 1;
                        unit.Range = 40;
                        unit.FirePower = 250;
                        break;
                    default:
                        throw new System.ArgumentException();
                }

                _units.Add(unitType, unit);

                return unit;
            }

        }



        private int infantryCount = 0;
        private int marineCount = 0;
        private int tankCount = 0;
        public Unit CreateUnit(UnitType unitType, GameObject prefab)
        {
            Unit unitBase = GetUnit(unitType);

            Unit newUnit = null;

            switch (unitType)
            {
                case UnitType.Infantry:
                    newUnit = new Soldier(unitType);
                    infantryCount++;
                    newUnit.Name += "_" + infantryCount.ToString();
                    break;
                case UnitType.Marine:
                    newUnit = new Soldier(unitType);
                    marineCount++;
                    newUnit.Name += "_" + marineCount.ToString();
                    break;
                case UnitType.Tank:
                    newUnit = new Tank();
                    tankCount++;
                    newUnit.Name += "_" + tankCount.ToString();
                    break;
                default:
                    throw new System.ArgumentException();
            }


            newUnit.Armor = unitBase.Armor;
            newUnit.Speed = unitBase.Speed;
            newUnit.RotationRate = unitBase.RotationRate;
            newUnit.FireRate = unitBase.FireRate;
            newUnit.Range = unitBase.Range;
            newUnit.FirePower = unitBase.FirePower;
            newUnit.ID = Guid.NewGuid();

            newUnit.gameObject = newUnit.Instantiate(prefab);

            UnitMonobehaviour umb = newUnit.gameObject.AddComponent<UnitMonobehaviour>();
            umb.unit = newUnit;
            newUnit.unitMonobehaviour = umb;

            return newUnit;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.flyweight_pattern.example2
{
    static class SoldierFlyweightFactory
    {
        private static Dictionary<WeaponType, ISoldierFlyweight> Soldiers = new Dictionary<WeaponType, ISoldierFlyweight>();
        public static int SoldierCount { get; private set; }

        public static ISoldierFlyweight Soldier(WeaponType weaponType)
        {
            if (!Soldiers.ContainsKey(weaponType))
            {
                switch (weaponType)
                {
                    case WeaponType.Sword:
                        Soldiers.Add(weaponType, new Knight());
                        break;
                    case WeaponType.Bow:
                        Soldiers.Add(weaponType, new Archer());
                        break;
                    case WeaponType.Lance:
                    default:
                        Soldiers.Add(weaponType, new Calvary());
                        break;
                }

                SoldierCount++;
            }

            return Soldiers[weaponType];
        }

    }
}

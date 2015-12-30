using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.flyweight_pattern.example2
{
    class Archer : ISoldierFlyweight
    {
        private SoldierStats _Stats = null;

        public SoldierStats Stats
        {
            get
            {
                if (_Stats == null)
                {
                    _Stats = new SoldierStats()
                    {
                        Attack = 15,
                        Defense = 4,
                        MaxHealth = 20,
                        Dexterity = 20,
                        Level = 1
                    };
                }

                return _Stats;
            }
        }

        public WeaponType Weapon
        {
            get
            {
                return WeaponType.Bow;
            }
        }

        

        public void LevelUp()
        {
            Stats.Level++;
            Stats.Attack += Stats.Level;
            Stats.Dexterity = (int)Math.Round(1.25f * Stats.Dexterity);
            Stats.MaxHealth += Stats.Level;
            Stats.Defense++;
        }

        public Color GetColor(int hitPoints)
        {
            if (hitPoints <= Stats.MaxHealth / 2)
                return Color.red;
            else
                return Color.green;
        }
    }


    class Knight : ISoldierFlyweight
    {
        private SoldierStats _Stats = null;

        public SoldierStats Stats
        {
            get
            {
                if (_Stats == null)
                {
                    _Stats = new SoldierStats()
                    {
                        Attack = 25,
                        Defense = 20,
                        MaxHealth = 30,
                        Dexterity = 5,
                        Level = 1
                    };
                }

                return _Stats;
            }
        }

        public WeaponType Weapon
        {
            get
            {
                return WeaponType.Sword;
            }
        }

        public void LevelUp()
        {
            Stats.Level++;
            Stats.Attack += (int)Math.Round(1.25f * Stats.Attack);
            Stats.Dexterity += Stats.Level / 2;
            Stats.MaxHealth += Stats.Level;
            Stats.Defense++;
        }

        public Color GetColor(int hitPoints)
        {
            if (hitPoints <= Stats.MaxHealth / 2)
                return Color.magenta;
            else
                return Color.gray;
        }
    }


    class Calvary : ISoldierFlyweight
    {
        private SoldierStats _Stats = null;

        public SoldierStats Stats
        {
            get
            {
                if (_Stats == null)
                {
                    _Stats = new SoldierStats()
                    {
                        Attack = 30,
                        Defense = 20,
                        MaxHealth = 25,
                        Dexterity = 10,
                        Level = 1
                    };
                }

                return _Stats;
            }
        }

        public WeaponType Weapon
        {
            get
            {
                return WeaponType.Lance;
            }
        }

        public void LevelUp()
        {
            Stats.Level++;
            Stats.Attack += Stats.Level / 2;
            Stats.Dexterity += Stats.Level / 2;
            Stats.MaxHealth += Stats.Level / 2;
            Stats.Defense++;
        }

        public Color GetColor(int hitPoints)
        {
            if (hitPoints <= Stats.MaxHealth / 2)
                return Color.yellow;
            else
                return Color.black;
        }
    }
}

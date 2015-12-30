using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.flyweight_pattern.example2
{
    interface ISoldierFlyweight
    {
        #region Intrinsic States

        SoldierStats Stats { get;}
        WeaponType Weapon { get; }
        // Operation that will affect all concrete soldiers.
        // This modifies the intrinsic state of Stats
        void LevelUp();

        #endregion


        #region Extrinsic State
        
        //Operation based on an extrinsic value, hitPoints
        UnityEngine.Color GetColor(int hitPoints);
        
        #endregion
    }

    public enum WeaponType
    {
        Sword, Bow, Lance
    }

    class SoldierStats
    {
        public int Attack;
        public int Defense;
        public int MaxHealth;
        public int Dexterity;
        public int Level;
    }
}

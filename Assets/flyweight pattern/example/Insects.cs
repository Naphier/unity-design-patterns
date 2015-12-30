using UnityEngine;
using System;
using System.Collections;

namespace NG.Flyweight.Example
{
    enum InsectType { fly, beetle, ant }

    abstract class InsectBase
    {
        // Total data size = 34 bytes
        // Imagine if we needed 10,000 of each insect, the data alone would require 3 * 10,000 * 34 = 102,000 bytes or 102kb
        // With the flyweight in use the shared data only ever requires at most 34 * 3 = 102 bytes
        #region Intrinsic States
        public InsectType insectType { get; protected set; }// 4 bytes
        protected int size;
        protected int legs;
        protected int eyes;
        protected int antennae;
        protected int toughness;
        public int maxHealth { get; protected set; }
        protected int hunger;
        protected bool canFly; // 1 byte
        protected bool canBurrow;
        #endregion

        #region Extrinsic State
        // Some "stateful" object - here an int that is calculated in the method.
        public abstract int GetStrength(int health);
        #endregion
    }

    class Insect : InsectBase
    {
        public Insect(InsectType insectType)
        {
            this.insectType = insectType;
            antennae = 2;
            legs = 6;

            switch (insectType)
            {
                case InsectType.fly:
                    size = 2;
                    eyes = 1000;
                    toughness = 1;
                    maxHealth = 100;
                    hunger = 100;
                    canFly = true;
                    canBurrow = false;
                    break;
                case InsectType.beetle:
                    size = 4;
                    eyes = 2;
                    toughness = 10;
                    maxHealth = 500;
                    hunger = 10;
                    canFly = true;
                    canBurrow = true;
                    break;
                case InsectType.ant:
                    size = 1;
                    eyes = 2;
                    toughness = 10;
                    maxHealth = 100;
                    hunger = 50;
                    canFly = false;
                    canBurrow = true;
                    break;
                default:
                    throw new ArgumentException();
            }
        }

        public override int GetStrength(int health)
        {
            return size + toughness + (canFly ? 1 : 0) + (canBurrow ? 1 : 0) + health;
        }
    }

    class InsectFlyweightFactory
    {
        public bool showMessages = false;

        private Hashtable _createdInsects = new Hashtable();

        public Insect GetInsectData(InsectType insectType)
        {
            if (_createdInsects.ContainsKey(insectType))
            {
                if (showMessages)
                    Debug.Log("Reusing " + insectType.ToString());

                return _createdInsects[insectType] as Insect;
            }
            else
            {
                if (showMessages)
                    Debug.LogWarning("Creating " + insectType.ToString());

                Insect insect = new Insect(insectType);
                _createdInsects.Add(insectType, insect);
                return insect;
            }
        }
    }
}

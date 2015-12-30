using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.decorator.example1
{
    abstract class MeleeAttack
    {
        public abstract int Attack();
    }


    class BaseMelee : MeleeAttack
    {
        public override int Attack()
        {
            int value = UnityEngine.Random.Range(1, 7); // 1d6
            return value;
        }
    }

    abstract class MeleeDecorator : MeleeAttack
    {
        MeleeAttack meleeAttack;

        public override int Attack()
        {
            if (meleeAttack != null)
                return meleeAttack.Attack();
            else
                return 0;
        }

        public void SetMeleeAttack(MeleeAttack meleeAttack)
        {
            this.meleeAttack = meleeAttack;
        }
    }

    class HardPunch : MeleeDecorator
    {
        public override int Attack()
        {
            return base.Attack() + 10;
        }
    }

    class KiPunch : MeleeDecorator
    {
        ParticleSystem particleSystem;

        public KiPunch(ParticleSystem particleSystem)
        {
            if (particleSystem == null)
                throw new ArgumentNullException("Particle system cannot be null");

            this.particleSystem = particleSystem;
        }

        public override int Attack()
        {
            AddedBehavior();
            return base.Attack() + 100;
        }

        void AddedBehavior()
        {
            if (particleSystem != null)
            {
                GameObject newPsys = GameObject.Instantiate(particleSystem.gameObject);
                newPsys.SetActive(true);

                DestroyOnTime dot = newPsys.AddComponent<DestroyOnTime>();

                dot.time = particleSystem.duration * 2f;
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.strategy_pattern.example
{
    public interface IEnemyBehaviour
    {
        void Move();
        void Attack();
    }

    public class DroneBehavior : IEnemyBehaviour
    {
        private float _attackTime;
        private float timeBetweenAttacks = 0.5f;
        private float movementSpeed = 2f;
        
        private enum direction { left, right}
        private direction moveDiection = direction.left;

        private GameObject gameObject;
        private float minX, maxX;

        public DroneBehavior(float startTime , GameObject gameObject , float minX, float maxX)
        {
            _attackTime = startTime;
            this.gameObject = gameObject;
            this.minX = minX;
            this.maxX = maxX;
        }

        public void Attack()
        {
            if (Time.time - _attackTime > timeBetweenAttacks)
            {
                _attackTime = Time.time;
                new Bullet(Color.cyan, gameObject.transform.position);
            }
        }

        public void Move()
        {
            Vector3 position = gameObject.transform.position;
            float newX = position.x;

            switch (moveDiection)
            {
                case direction.left:
                    newX = position.x - Time.deltaTime * movementSpeed;
                    if (newX < minX)
                    {
                        moveDiection = direction.right;
                    }
                    else
                    {
                        position.x = newX;
                    }
                    break;
                case direction.right:
                    newX = position.x + Time.deltaTime * movementSpeed;
                    if (newX > maxX)
                    {
                        moveDiection = direction.left;
                    }
                    else
                    {
                        position.x = newX;
                    }
                    break;
            }

            gameObject.transform.position = position;
        }
    }


    public class FighterBehavior : IEnemyBehaviour
    {
        private float _attackTime;
        private float timeBetweenAttacks = 0.25f;
        private float movementSpeed = 4f;

        private enum direction { left, right }
        private direction moveDiection = direction.left;

        private GameObject gameObject;
        private float minX, maxX;

        public FighterBehavior(float startTime, GameObject gameObject, float minX, float maxX)
        {
            _attackTime = startTime;
            this.gameObject = gameObject;
            this.minX = minX;
            this.maxX = maxX;
        }

        public void Attack()
        {
            if (Time.time - _attackTime > timeBetweenAttacks)
            {
                _attackTime = Time.time;
                new Bullet(Color.magenta, gameObject.transform.position);
            }
        }

        public void Move()
        {
            Vector3 position = gameObject.transform.position;
            float newX = position.x;

            switch (moveDiection)
            {
                case direction.left:
                    newX = position.x - Time.deltaTime * movementSpeed;
                    if (newX < minX)
                    {
                        moveDiection = direction.right;
                        position.y -= gameObject.transform.localScale.y;
                    }
                    else
                    {
                        position.x = newX;
                    }
                    break;
                case direction.right:
                    newX = position.x + Time.deltaTime * movementSpeed;
                    if (newX > maxX)
                    {
                        moveDiection = direction.left;
                        position.y -= gameObject.transform.localScale.y;
                    }
                    else
                    {
                        position.x = newX;
                    }
                    break;
            }

            gameObject.transform.position = position;
        }
    }


    public class EnemyBehaviorContext
    {
        private IEnemyBehaviour enemyBehavior;
        public EnemyBehaviorContext(IEnemyBehaviour enemyBehavior)
        {
            this.enemyBehavior = enemyBehavior;
        }

        public void Act()
        {
            enemyBehavior.Attack();
            enemyBehavior.Move();
        }
    }

    /// <summary>
    /// Not part of the pattern, but just a convenience class to create our bullets.
    /// </summary>
    public class Bullet
    {
        public Bullet(Color color, Vector3 position)
        {
            GameObject bullet = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            bullet.transform.localScale = 0.5f * Vector3.one;
            bullet.GetComponent<MeshRenderer>().material.color = color;
            Rigidbody rb = bullet.AddComponent<Rigidbody>();
            rb.useGravity = false;
            rb.AddForce(1000f * Vector3.down);
            bullet.GetComponent<Collider>().isTrigger = true;
            bullet.transform.position = position;
            bullet.AddComponent<DestroyOnTime>().time = 0.5f;
        }
    }
}

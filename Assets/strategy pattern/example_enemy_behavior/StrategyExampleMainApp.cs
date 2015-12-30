using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Assets.strategy_pattern.example;
public class StrategyExampleMainApp : MonoBehaviour
{
    List<EnemyBehaviorContext> enemyBehaviors = new List<EnemyBehaviorContext>();
    public GameObject spawnPoint;
    public float minX, maxX;
    void Start()
    {
        StartCoroutine(MakeEnemies());  
    }

    IEnumerator MakeEnemies()
    {
        for (int i = 0; i < 10; i++)
        {
            GameObject enemy = GameObject.CreatePrimitive(PrimitiveType.Cube);
            

            enemy.transform.position = spawnPoint.transform.position;

            EnemyBehaviorContext context;
            IEnemyBehaviour enemyBehavior;
            if (i < 5)
            {
                enemy.name = "Drone";
                enemyBehavior = new DroneBehavior(Time.time, enemy, minX, maxX);
                enemy.GetComponent<MeshRenderer>().material.color = Color.blue;
            }
            else
            {
                enemy.name = "Fighter";
                enemyBehavior = new FighterBehavior(Time.time, enemy, minX, maxX);
                enemy.GetComponent<MeshRenderer>().material.color = Color.red;
            }

            context = new EnemyBehaviorContext(enemyBehavior);
            enemyBehaviors.Add(context);

            yield return new WaitForSeconds(1f);
        }
    }


    void Update()
    {
        for (int i = 0; i < enemyBehaviors.Count; i++)
        {
            enemyBehaviors[i].Act();
        }
    }
}

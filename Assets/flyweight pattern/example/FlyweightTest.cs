using UnityEngine;
using System;
using System.Collections.Generic;
using System.Linq;

public class FlyweightTest : MonoBehaviour
{
    private static Dictionary<Guid, Unit> unitsOnField = new Dictionary<Guid, Unit>();

    public GameObject infantryPrefab;
    public GameObject marinePrefab;
    public GameObject tankPrefab;
    public static GameObject bulletBase;

    public Transform min;
    public Transform max;
    public int numberOfUnits = 10;

    void Start()
    {
        bulletBase = GameObject.Find("bulletbase");
        if (bulletBase == null)
            Debug.LogError("bullet base not found");

        UnitFactory factory = new UnitFactory();

        for (int i = 0; i < numberOfUnits; i++)
        {
            float x = UnityEngine.Random.Range(min.position.x, max.position.x);
            float y = UnityEngine.Random.Range(min.position.y, max.position.y);

            UnitType randomType = (UnitType)UnityEngine.Random.Range(0, 3);
            Unit unit = null;
            switch (randomType)
            {
                case UnitType.Infantry:
                    unit = factory.CreateUnit(randomType, infantryPrefab);
                    break;
                case UnitType.Marine:
                    unit = factory.CreateUnit(randomType, marinePrefab);
                    break;
                case UnitType.Tank:
                    unit = factory.CreateUnit(randomType, tankPrefab);
                    break;
                default:
                    throw new System.ArgumentException();
            }

            if (unit != null)
            {
                Vector3 temp = unit.gameObject.transform.position;
                temp.x = x;
                temp.y = y;
                unit.gameObject.transform.position = temp;
                unitsOnField.Add(unit.ID, unit);
            }
        }

        SetTargets();
    }

    public static GameObject GetUnitGameObjectById(Guid unitId)
    {
        if (unitsOnField.ContainsKey(unitId))
        {
            return unitsOnField[unitId].gameObject;
        }

        return null;
    }

    public static void SetTarget(Guid unitId)
    {
        if (unitsOnField.ContainsKey(unitId))
        {
            Unit unit = unitsOnField[unitId];
            unit.targetId = GetRandomTargetID(unitId);
        }
    }

    void SetTargets()
    {
        foreach (KeyValuePair<Guid,Unit> unitOnField in unitsOnField)
        {
            GameObject target = null;
            if (unitsOnField.ContainsKey(unitOnField.Value.targetId))
                target = unitsOnField[unitOnField.Value.targetId].gameObject;

            if (target == null)
            {
                unitOnField.Value.targetId = GetRandomTargetID(unitOnField.Key);
            }
        }
    }

    private static Guid GetRandomTargetID(Guid unitId)
    {
        int attemptLoop = 0;
        System.Random rand = new System.Random();
        int randStart = rand.Next(0, unitsOnField.Count);
        Guid randomTargetId = unitsOnField.ElementAt(randStart).Key;
        while (randomTargetId == unitId)
        {
            randStart++;
            if (randStart >= unitsOnField.Count)
            {
                randStart = 0;
                attemptLoop++;
                if (attemptLoop > 1)
                    break;
            }

            randomTargetId = unitsOnField.ElementAt(randStart).Key;
        }

        if (randomTargetId == unitId)
            randomTargetId = Guid.Empty;
        return randomTargetId;

    }

    public static void DestroyUnit(Guid unitId)
    {
        if (unitsOnField.ContainsKey(unitId))
        {
            Destroy(unitsOnField[unitId].gameObject);
            unitsOnField.Remove(unitId);
        }
    }

    public static BulletBehaviour MakeBullet(Guid targetId, GameObject creator)
    {
        if (bulletBase != null)
        {
            GameObject newBullet = Instantiate(bulletBase);
            BulletBehaviour bb = newBullet.AddComponent<BulletBehaviour>();
            bb.target = GetUnitGameObjectById(targetId);
            bb.creator = creator;
            bb.transform.position = creator.transform.position;
            return bb;
        }

        return null;
    }


    public void TimeScale(float scale)
    {
        Time.timeScale = scale;
    }
}

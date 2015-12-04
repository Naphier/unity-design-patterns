using UnityEngine;
using System;

public class UnitMonobehaviour : MonoBehaviour
{
    public Unit unit;
    private TextMesh textMesh;
    void Start()
    {
        if (unit == null)
        {
            Debug.LogError("unit is null on start");
            Destroy(gameObject);
        }

        textMesh = gameObject.GetComponentInChildren<TextMesh>();
        if (textMesh == null)
            Debug.LogError("text mest not found");
    }

    void Update()
    {
        if (FlyweightTest.GetUnitGameObjectById(unit.targetId) == null)
        {
            FlyweightTest.SetTarget(unit.ID);
        }
        else
        {
            if (unit.CanShoot())
            {
                unit.FireAt(unit.targetId);
            }
        }

        if (textMesh != null)
            textMesh.text = unit.Armor.ToString();
    }


    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "bullet")
        {
            BulletBehaviour bb = other.gameObject.GetComponent<BulletBehaviour>();

            if (bb != null)
            {
                if (bb.creator == gameObject)
                    return;

                unit.Armor -= bb.firePower;
                if (unit.Armor <= 0)
                {
                    FlyweightTest.DestroyUnit(unit.ID);
                }
            }
        }
    }
}

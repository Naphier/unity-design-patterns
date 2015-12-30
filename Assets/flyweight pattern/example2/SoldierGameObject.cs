using UnityEngine;
using System.Collections;
using Assets.flyweight_pattern.example2;

public class SoldierGameObject : MonoBehaviour
{
    private ISoldierFlyweight soldier = null;
    public int health = 0;

    public void Create(WeaponType weaponType)
    {
        soldier = SoldierFlyweightFactory.Soldier(weaponType);
        gameObject.AddComponent<BoxCollider>();
    }

    bool mouseOver = false;
    void OnMouseOver()
    {
        mouseOver = true;

        if (soldier != null)
        {
            if (Input.GetMouseButtonDown(1))
            {
                // NOTE: Since health is extrinsic to the SoldierFlyweight
                //  we need to make any adjustments to it specifically here.
                //  Unfortunately, this means it is not simple to increase
                //  the health on ALL SoldierGameObjects on the field.
                int addHealth = soldier.Stats.MaxHealth;
                soldier.LevelUp();
                addHealth = soldier.Stats.MaxHealth - addHealth;
                health += addHealth;
                Debug.LogFormat("Leveling up all {0} soldiers to level {1}", soldier.Weapon, soldier.Stats.Level);
            }
            else if (Input.GetMouseButtonDown(0))
            {
                health -= 5;
                if (health <= 0)
                    Destroy(gameObject);
                else
                {
                    gameObject.GetComponent<MeshRenderer>().material.color = soldier.GetColor(health);
                }
            }
        }
    }

    void OnMouseExit()
    {
        mouseOver = false;
    }

    void OnGUI()
    {
        if (!mouseOver)
            return;
        if (soldier == null)
            return;

        string soldierInfo = string.Format(
            "Weapon: {0}\nLevel: {1}\nAttack: {2}\nDexterity: {3}\nMaxHealth: {4}\nDefense: {5}\nhealth: {6}",
            soldier.Weapon,
            soldier.Stats.Level,
            soldier.Stats.Attack,
            soldier.Stats.Dexterity,
            soldier.Stats.MaxHealth,
            soldier.Stats.Defense,
            health
            );

        GUI.Label(new Rect(0, 50, 1000, 1000), soldierInfo);
    }
}
